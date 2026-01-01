Imports MySql.Data.MySqlClient
Imports iTextSharp.text
Imports iTextSharp.text.pdf
Imports System.IO
Imports System.Text
Imports OfficeOpenXml
Imports OfficeOpenXml.Style
Imports System.ComponentModel
Imports System.Drawing



Public Class FormReport

    Private Sub FormReport_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        ' === CEK ROLE ===
        If RoleUser <> "MANAGER" Then
            MessageBox.Show("Form ini hanya untuk Manager",
                        "Akses Ditolak",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning)

            Me.Close()
            Exit Sub
        End If



        SetupDGV()
        LoadHasil()
        StyleButton()
    End Sub

    ' ================= SETUP DGV =================
    Sub SetupDGV()
        dgvHasil.Columns.Clear()
        dgvHasil.AllowUserToAddRows = False
        dgvHasil.ReadOnly = True
        dgvHasil.SelectionMode = DataGridViewSelectionMode.FullRowSelect

        dgvHasil.Columns.Add("nama", "Nama Karyawan")
        dgvHasil.Columns.Add("nilai", "Nilai Akhir")
        dgvHasil.Columns.Add("rank", "Ranking")
        dgvHasil.Columns.Add("rek", "Rekomendasi")
        dgvHasil.Columns.Add("status", "Status Approval")

        dgvHasil.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
        dgvHasil.EnableHeadersVisualStyles = False
        dgvHasil.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(45, 45, 48)
        dgvHasil.ColumnHeadersDefaultCellStyle.ForeColor = Color.White
    End Sub

    ' ================= LOAD HASIL =================
    Sub LoadHasil()
        dgvHasil.Rows.Clear()

        Dim sql As String =
        "SELECT k.nama_karyawan, h.nilai_akhir, h.ranking,
                h.rekomendasi, h.status_approval
         FROM hasil h
         JOIN karyawan k ON h.id_karyawan = k.id_karyawan
         ORDER BY h.ranking ASC"

        Using da As New MySqlDataAdapter(sql, conn)
            Dim dt As New DataTable
            da.Fill(dt)

            For Each r As DataRow In dt.Rows
                dgvHasil.Rows.Add(
                    r("nama_karyawan"),
                    Math.Round(CDbl(r("nilai_akhir")), 0),
                    r("ranking"),
                    r("rekomendasi"),
                    r("status_approval")
                )
            Next
        End Using

        WarnaiRow()
    End Sub

    ' ================= WARNA ROW =================
    Sub WarnaiRow()
        For Each row As DataGridViewRow In dgvHasil.Rows
            If row.IsNewRow Then Continue For

            Select Case row.Cells("status").Value.ToString()
                Case "Approved"
                    row.DefaultCellStyle.BackColor = Color.PaleGreen
                Case "Rejected"
                    row.DefaultCellStyle.BackColor = Color.MistyRose
                Case Else
                    row.DefaultCellStyle.BackColor = Color.White
            End Select

            If CInt(row.Cells("rank").Value) = 1 Then
                row.DefaultCellStyle.Font =
                    New System.Drawing.Font("Segoe UI", 9, FontStyle.Bold)
            End If
        Next
    End Sub

    ' ================= STYLE BUTTON =================
    Sub StyleButton()
        btnApprove.BackColor = Color.FromArgb(46, 204, 113)
        btnApprove.ForeColor = Color.White

        btnReject.BackColor = Color.FromArgb(231, 76, 60)
        btnReject.ForeColor = Color.White

        btnExportExcel.BackColor = Color.FromArgb(52, 152, 219)
        btnExportExcel.ForeColor = Color.White

        btnExportPDF.BackColor = Color.FromArgb(155, 89, 182)
        btnExportPDF.ForeColor = Color.White
    End Sub

    ' ================= APPROVE =================
    Private Sub btnApprove_Click(sender As Object, e As EventArgs) Handles btnApprove.Click
        If MessageBox.Show("Approve seluruh hasil penilaian?",
                           "Konfirmasi",
                           MessageBoxButtons.YesNo,
                           MessageBoxIcon.Question) = DialogResult.No Then Exit Sub

        OpenConn()
        Dim cmd As New MySqlCommand("
            UPDATE hasil SET
            status_approval='Approved',
            catatan_manager=@catatan,
            approved_at=NOW()", conn)

        cmd.Parameters.AddWithValue("@catatan", txtCatatan.Text)
        cmd.ExecuteNonQuery()
        conn.Close()

        LoadHasil()
        MessageBox.Show("Hasil berhasil di-APPROVE")
    End Sub

    ' ================= REJECT =================
    Private Sub btnReject_Click(sender As Object, e As EventArgs) Handles btnReject.Click
        If txtCatatan.Text.Trim = "" Then
            MessageBox.Show("Catatan wajib diisi untuk Reject")
            Exit Sub
        End If

        OpenConn()
        Dim cmd As New MySqlCommand("
            UPDATE hasil SET
            status_approval='Rejected',
            catatan_manager=@catatan,
            approved_at=NOW()", conn)

        cmd.Parameters.AddWithValue("@catatan", txtCatatan.Text)
        cmd.ExecuteNonQuery()
        conn.Close()

        LoadHasil()
        MessageBox.Show("Hasil berhasil di-REJECT")
    End Sub



    Private Sub btnExportExcel_Click(sender As Object, e As EventArgs) Handles btnExportExcel.Click

        Dim sfd As New SaveFileDialog With {
        .Filter = "Excel File|*.xlsx",
        .FileName = "Laporan_Penilaian_Karyawan.xlsx"
    }
        If sfd.ShowDialog() <> DialogResult.OK Then Exit Sub

        Using package As New ExcelPackage()
            Dim ws = package.Workbook.Worksheets.Add("Laporan")

            ' ===== PAGE SETUP =====
            ws.PrinterSettings.PaperSize = ePaperSize.A4
            ws.PrinterSettings.Orientation = eOrientation.Portrait
            ws.PrinterSettings.HorizontalCentered = True
            ws.View.ShowGridLines = False

            ws.Row(1).Height = 35
            ws.Row(2).Height = 22

            ' ===== LOGO (RESOURCE) =====
            Using msLogo As New MemoryStream()
                My.Resources.logo.Save(msLogo, Imaging.ImageFormat.Png)
                msLogo.Position = 0
                Dim logo = ws.Drawings.AddPicture("Logo", msLogo)
                logo.SetPosition(0, 5, 0, 5)
                logo.SetSize(60, 60)
                logo.EditAs = OfficeOpenXml.Drawing.eEditAs.OneCell
            End Using

            ' ===== JUDUL =====
            ws.Cells("A1:F1").Merge = True
            ws.Cells("A1").Value = "LAPORAN HASIL PENILAIAN KARYAWAN"
            ws.Cells("A1").Style.Font.Size = 16
            ws.Cells("A1").Style.Font.Bold = True
            ws.Cells("A1").Style.HorizontalAlignment = ExcelHorizontalAlignment.Center

            ws.Cells("A2:F2").Merge = True
            ws.Cells("A2").Value = "Periode Tahun " & Date.Now.Year
            ws.Cells("A2").Style.Font.Italic = True
            ws.Cells("A2").Style.HorizontalAlignment = ExcelHorizontalAlignment.Center

            ' ===== HEADER =====
            Dim headerRow As Integer = 4
            Dim headers = {"Nama Karyawan", "Nilai Akhir", "Ranking", "Rekomendasi", "Status"}

            For i = 0 To headers.Length - 1
                ws.Cells(headerRow, i + 1).Value = headers(i)
            Next

            Using h = ws.Cells($"A{headerRow}:E{headerRow}")
                h.Style.Font.Bold = True
                h.Style.Fill.PatternType = ExcelFillStyle.Solid
                h.Style.Fill.BackgroundColor.SetColor(Color.LightGray)
                h.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center
                h.Style.Border.BorderAround(ExcelBorderStyle.Medium)
            End Using
            ' ===== DATA =====
            Dim rowExcel As Integer = headerRow + 1
            Dim zebra As Boolean = False

            For Each r As DataGridViewRow In dgvHasil.Rows
                If r.IsNewRow Then Continue For

                ws.Cells(rowExcel, 1).Value = r.Cells("nama").Value
                ws.Cells(rowExcel, 2).Value = r.Cells("nilai").Value
                ws.Cells(rowExcel, 3).Value = r.Cells("rank").Value
                ws.Cells(rowExcel, 4).Value = r.Cells("rek").Value
                ws.Cells(rowExcel, 5).Value = "✔ Approved"

                ' ===== ALIGNMENT =====
                ws.Cells(rowExcel, 2).Style.HorizontalAlignment = ExcelHorizontalAlignment.Center
                ws.Cells(rowExcel, 3).Style.HorizontalAlignment = ExcelHorizontalAlignment.Center
                ws.Cells(rowExcel, 5).Style.HorizontalAlignment = ExcelHorizontalAlignment.Center

                ' ===== WARNA REKOMENDASI (PRIORITAS) =====
                Dim rekom = ws.Cells(rowExcel, 4).Value.ToString().ToLower()
                With ws.Cells(rowExcel, 4).Style
                    .Font.Bold = True
                    .Fill.PatternType = ExcelFillStyle.Solid
                End With

                Select Case True
                    Case rekom.Contains("reward")
                        ws.Cells(rowExcel, 4).Style.Fill.BackgroundColor.SetColor(Color.FromArgb(198, 239, 206)) ' hijau
                    Case rekom.Contains("dipertahankan")
                        ws.Cells(rowExcel, 4).Style.Fill.BackgroundColor.SetColor(Color.FromArgb(189, 215, 238)) ' biru
                    Case rekom.Contains("pembinaan")
                        ws.Cells(rowExcel, 4).Style.Fill.BackgroundColor.SetColor(Color.FromArgb(255, 242, 204)) ' kuning
                    Case rekom.Contains("punishment")
                        ws.Cells(rowExcel, 4).Style.Fill.BackgroundColor.SetColor(Color.FromArgb(244, 204, 204)) ' merah
                End Select

                ' ===== ZEBRA ROW (TANPA KOLOM REKOMENDASI) =====
                If zebra Then
                    ws.Cells($"A{rowExcel}:C{rowExcel}").Style.Fill.PatternType = ExcelFillStyle.Solid
                    ws.Cells($"A{rowExcel}:C{rowExcel}").Style.Fill.BackgroundColor.SetColor(Color.FromArgb(242, 242, 242))
                    ws.Cells($"E{rowExcel}").Style.Fill.PatternType = ExcelFillStyle.Solid
                    ws.Cells($"E{rowExcel}").Style.Fill.BackgroundColor.SetColor(Color.FromArgb(242, 242, 242))
                End If
                zebra = Not zebra

                rowExcel += 1
            Next


            ws.Cells.AutoFitColumns()

            ' ===== TTD =====
            rowExcel += 2
            ws.Cells($"D{rowExcel}:E{rowExcel}").Merge = True
            ws.Cells(rowExcel, 4).Value = "Mengetahui,"
            ws.Cells(rowExcel, 4).Style.HorizontalAlignment = ExcelHorizontalAlignment.Center

            Using msTTD As New MemoryStream()
                My.Resources.TTD_Manager.Save(msTTD, Imaging.ImageFormat.Png)
                msTTD.Position = 0
                Dim ttd = ws.Drawings.AddPicture("TTD", msTTD)
                ttd.SetPosition(rowExcel, 20, 3, 20)
                ttd.SetSize(120, 60)
            End Using

            rowExcel += 4
            ws.Cells($"D{rowExcel}:E{rowExcel}").Merge = True
            ws.Cells(rowExcel, 4).Value = "Achmad Sofyan"
            ws.Cells(rowExcel, 4).Style.Font.Bold = True
            ws.Cells(rowExcel, 4).Style.HorizontalAlignment = ExcelHorizontalAlignment.Center

            rowExcel += 1
            ws.Cells($"D{rowExcel}:E{rowExcel}").Merge = True
            ws.Cells(rowExcel, 4).Value = "Manager HRD"
            ws.Cells(rowExcel, 4).Style.HorizontalAlignment = ExcelHorizontalAlignment.Center

            Dim fi As New FileInfo(sfd.FileName)
            If fi.Exists Then fi.Delete()
            package.SaveAs(fi)
        End Using

        MessageBox.Show("Excel berhasil diexport")
    End Sub


    ' ================= EXPORT PDF =================


    Private Sub btnExportPDF_Click(sender As Object, e As EventArgs) Handles btnExportPDF.Click

        Dim save As New SaveFileDialog With {
        .Filter = "PDF File|*.pdf",
        .FileName = "Laporan_Penilaian_Karyawan.pdf"
    }
        If save.ShowDialog() <> DialogResult.OK Then Exit Sub

        Dim doc As New iTextSharp.text.Document(PageSize.A4, 40, 40, 40, 40)
        Dim writer = PdfWriter.GetInstance(doc, New FileStream(save.FileName, FileMode.Create))
        doc.Open()

        ' ================= WATERMARK =================
        Dim cb = writer.DirectContentUnder
        cb.SaveState()

        Dim gs As New PdfGState()
        gs.FillOpacity = 0.12F
        cb.SetGState(gs)

        Dim wmFont As New iTextSharp.text.Font(
        iTextSharp.text.Font.FontFamily.HELVETICA,
        60,
        iTextSharp.text.Font.BOLD,
        New BaseColor(0, 150, 0)
    )

        ColumnText.ShowTextAligned(
        cb,
        Element.ALIGN_CENTER,
        New Phrase("APPROVED", wmFont),
        300,
        400,
        45
    )

        cb.RestoreState()

        ' ================= LOGO =================
        Dim logo = iTextSharp.text.Image.GetInstance(My.Resources.logo, Imaging.ImageFormat.Png)
        logo.ScaleToFit(60, 60)
        logo.SetAbsolutePosition(40, 770)
        doc.Add(logo)

        ' ================= FONT =================
        Dim titleFont As New iTextSharp.text.Font(
        iTextSharp.text.Font.FontFamily.HELVETICA,
        14,
        iTextSharp.text.Font.BOLD
    )

        Dim bodyFont As New iTextSharp.text.Font(
        iTextSharp.text.Font.FontFamily.HELVETICA,
        9,
        iTextSharp.text.Font.NORMAL
    )

        Dim headerFont As New iTextSharp.text.Font(
        iTextSharp.text.Font.FontFamily.HELVETICA,
        9,
        iTextSharp.text.Font.BOLD
    )

        ' ================= TITLE =================
        Dim title As New Paragraph("LAPORAN HASIL PENILAIAN KARYAWAN", titleFont)
        title.Alignment = Element.ALIGN_CENTER
        doc.Add(title)

        doc.Add(New Paragraph("Periode Tahun " & Date.Now.Year, bodyFont) With {
        .Alignment = Element.ALIGN_CENTER,
        .SpacingAfter = 15
    })

        ' ================= TABLE =================
        Dim table As New PdfPTable(4)
        table.WidthPercentage = 100
        table.SetWidths({4, 2, 2, 3})

        ' Header
        Dim headers = {"Nama Karyawan", "Nilai Akhir", "Ranking", "Rekomendasi"}
        For Each h In headers
            table.AddCell(New PdfPCell(New Phrase(h, headerFont)) With {
            .BackgroundColor = New BaseColor(217, 217, 217),
            .HorizontalAlignment = Element.ALIGN_CENTER,
            .Padding = 5
        })
        Next

        ' Data
        For Each r As DataGridViewRow In dgvHasil.Rows
            If r.IsNewRow Then Continue For

            table.AddCell(New PdfPCell(New Phrase(r.Cells("nama").Value.ToString(), bodyFont)) With {.Padding = 5})

            table.AddCell(New PdfPCell(New Phrase(r.Cells("nilai").Value.ToString(), bodyFont)) With {
            .HorizontalAlignment = Element.ALIGN_CENTER,
            .Padding = 5
        })

            table.AddCell(New PdfPCell(New Phrase(r.Cells("rank").Value.ToString(), bodyFont)) With {
            .HorizontalAlignment = Element.ALIGN_CENTER,
            .Padding = 5
        })

            Dim rekomText = r.Cells("rek").Value.ToString()
            Dim rekomLower = rekomText.ToLower()
            Dim bgColor As BaseColor = BaseColor.WHITE

            If rekomLower.Contains("reward") Then
                bgColor = New BaseColor(198, 239, 206)
            ElseIf rekomLower.Contains("dipertahankan") Then
                bgColor = New BaseColor(189, 215, 238)
            ElseIf rekomLower.Contains("pembinaan") Then
                bgColor = New BaseColor(255, 242, 204)
            ElseIf rekomLower.Contains("punishment") Then
                bgColor = New BaseColor(244, 204, 204)
            End If

            table.AddCell(New PdfPCell(New Phrase(rekomText, bodyFont)) With {
            .BackgroundColor = bgColor,
            .Padding = 5
        })
        Next

        doc.Add(table)
        doc.Add(New Paragraph(" "))

        ' ================= TTD =================
        doc.Add(New Paragraph("Mengetahui,", bodyFont))
        doc.Add(New Paragraph(" "))

        Dim ttd = iTextSharp.text.Image.GetInstance(My.Resources.TTD_Manager, Imaging.ImageFormat.Png)
        ttd.ScaleToFit(120, 60)
        doc.Add(ttd)

        doc.Add(New Paragraph("Achmad Sofyan", bodyFont))
        doc.Add(New Paragraph("Manager HRD", bodyFont))
        doc.Add(New Paragraph("Tanggal Cetak: " & Date.Now.ToString("dd MMMM yyyy"), bodyFont))

        doc.Close()
        MessageBox.Show("PDF berhasil diexport", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information)

    End Sub

    Private Sub btnMenu_Click(sender As Object, e As EventArgs) Handles btnMenu.Click
        FormMenu.Show()
        Me.Close()
    End Sub

    Private Sub Label1_Click(sender As Object, e As EventArgs) Handles Label1.Click

    End Sub
End Class
