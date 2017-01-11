Imports System.Data.SqlClient

Module Commands

    Public Function Execute(ByVal command As String, ByVal sqlConn As String) As String
        Dim conn As New SqlConnection(sqlConn)

        Dim _command As String() = command.Split(";")

        Try
            Select Case _command(0)
                Case TextCodes.PO
                    If _command.Length > 4 Or _command.Length < 3 Then
                        Return TextResponse.ERROR_PARAMETERS
                    End If

                    Dim code As String = _command(0)
                    Dim name As String = _command(1)
                    Dim address As String = _command(2)
                    Dim remarks As String = ""

                    If Not _command(3).Trim = "" Then
                        remarks = _command(3)
                    End If

                    Using (conn)

                        Dim cmd As New SqlCommand()

                        cmd.Connection = conn

                        cmd.CommandText = "pr_test_create_po"
                        cmd.CommandType = CommandType.StoredProcedure

                        cmd.Parameters.AddWithValue("customer_name", name)
                        cmd.Parameters.AddWithValue("address", address)
                        cmd.Parameters.AddWithValue("remarks", remarks)

                        conn.Open()

                        cmd.ExecuteNonQuery()

                    End Using

                    Return TextResponse.PO_SUCCESS
                Case Else
                    Return TextResponse.ERROR_TEXT_CODE
            End Select
        Catch ex As SqlException
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Sql Exception")
        Catch e As Exception
            MsgBox(e.Message, MsgBoxStyle.Critical)
        End Try

        'UNKNOWN ERROR
        Return ""

    End Function


End Module
