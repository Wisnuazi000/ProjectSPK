Namespace My
    Partial Friend Class MyApplication

        Private Sub MyApplication_Startup(
            sender As Object,
            e As ApplicationServices.StartupEventArgs
        ) Handles Me.Startup

            ' === SET LICENSE EPPLUS (PALING AWAL) ===
            Environment.SetEnvironmentVariable(
                "EPPlus_LicenseContext",
                "NonCommercial",
                EnvironmentVariableTarget.Process
            )

        End Sub

    End Class
End Namespace
