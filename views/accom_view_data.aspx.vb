Imports System.Data
Imports Easyway.BE
Imports Easyway.DL
Imports System.IO

Partial Class accom_view_data
    Inherits System.Web.UI.Page

    Dim objFunction As New clsCommon()
    Dim objBEAccomodation As clsBEAccomodation = New clsBEAccomodation
    Dim objDLAccomodation As clsDLAccomodation = New clsDLAccomodation

    ''' <summary>
    ''' Load event of the page
    ''' </summary>
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Try
            If Not objFunction.ValidateLogin() Then
                Response.Redirect("~/login.aspx")
            End If

            If Not Page.IsPostBack Then

            End If

        Catch ex As Exception
            HttpContext.Current.Trace.Warn("Exception message:  ::", ex.Message)
            HttpContext.Current.Trace.Warn("Error Stack Trace ::", ex.StackTrace)
        End Try

    End Sub

    Protected Sub BUT_Download_Accom_Data_Click(sender As Object, e As System.EventArgs) Handles BUT_Download_Accom_Data.Click
        Try
            Dim intCompanyId As Integer = objFunction.ReturnInteger(Session("CompanyId"))
            Dim dstData As DataSet = (New clsDLAccomodation()).GetAccommodationDetailFillInDD(intCompanyId)

            If File.Exists(Server.MapPath("~/DownloadCSV/DownloadAccomData.csv")) Then
                File.Delete(Server.MapPath("~/DownloadCSV/DownloadAccomData.csv"))
            End If

            Dim strFilePath As String = Server.MapPath("~/DownloadCSV/DownloadAccomData.csv")
            Dim objStreamWriter As IO.StreamWriter = My.Computer.FileSystem.OpenTextFileWriter(strFilePath, True)

            Dim strHeaderLine As String
            strHeaderLine = "Accom Name," + "Contact," + "Email"
            objStreamWriter.WriteLine(strHeaderLine)

            If objFunction.CheckDataSet(dstData) Then
                For i = 0 To dstData.Tables(0).Rows.Count - 1
                    Dim strFileData As String = objFunction.ReturnString(dstData.Tables(0).Rows(i)("name")).Replace(",", " ") + "," +
                                                objFunction.ReturnString(dstData.Tables(0).Rows(i)("contact")).Replace(",", " ") + "," +
                                                objFunction.ReturnString(dstData.Tables(0).Rows(i)("email"))
                    objStreamWriter.WriteLine(strFileData)
                Next
            End If

            objStreamWriter.Close()

            Dim memStream As New MemoryStream()
            Using fileStream As FileStream = File.OpenRead(Server.MapPath("~/DownloadCSV/DownloadAccomData.csv"))
                memStream.SetLength(fileStream.Length)
                fileStream.Read(memStream.GetBuffer(), 0, CInt(Fix(fileStream.Length)))
            End Using

            If File.Exists(Server.MapPath("~/DownloadCSV/DownloadAccomData.csv")) Then
                File.Delete(Server.MapPath("~/DownloadCSV/DownloadAccomData.csv"))
            End If

            Response.Clear()
            Response.ContentType = "application/force-download"
            Response.AddHeader("content-disposition", "attachment; filename=DownloadAccomData.csv")
            Response.Buffer = True
            Dim bytes = memStream.ToArray()
            Response.OutputStream.Write(bytes, 0, bytes.Length)
            Response.OutputStream.Flush()
            Response.End()
        Catch ex As Exception
            HttpContext.Current.Trace.Warn("Exception message:  ::", ex.Message)
            HttpContext.Current.Trace.Warn("Error Stack Trace ::", ex.StackTrace)
        End Try
    End Sub

    Protected Sub BUT_Download_Agents_Data_Click(sender As Object, e As System.EventArgs) Handles BUT_Download_Agents_Data.Click
        Try
            Dim intCompanyId As Integer = objFunction.ReturnInteger(Session("CompanyId"))
            Dim dstData As DataSet = (New clsDLAgent()).GetAgentDetailFillInDD(intCompanyId)

            If File.Exists(Server.MapPath("~/DownloadCSV/DownloadAgentsData.csv")) Then
                File.Delete(Server.MapPath("~/DownloadCSV/DownloadAgentsData.csv"))
            End If

            Dim strFilePath As String = Server.MapPath("~/DownloadCSV/DownloadAgentsData.csv")
            Dim objStreamWriter As IO.StreamWriter = My.Computer.FileSystem.OpenTextFileWriter(strFilePath, True)

            Dim strHeaderLine As String
            strHeaderLine = "Accom Name," + "Contact," + "Email"
            objStreamWriter.WriteLine(strHeaderLine)

            If objFunction.CheckDataSet(dstData) Then
                For i = 0 To dstData.Tables(0).Rows.Count - 1
                    Dim strFileData As String = objFunction.ReturnString(dstData.Tables(0).Rows(i)("name")).Replace(",", " ") + "," +
                                                objFunction.ReturnString(dstData.Tables(0).Rows(i)("contactname")).Replace(",", " ") + "," +
                                                objFunction.ReturnString(dstData.Tables(0).Rows(i)("email"))
                    objStreamWriter.WriteLine(strFileData)
                Next
            End If

            objStreamWriter.Close()

            Dim memStream As New MemoryStream()
            Using fileStream As FileStream = File.OpenRead(Server.MapPath("~/DownloadCSV/DownloadAgentsData.csv"))
                memStream.SetLength(fileStream.Length)
                fileStream.Read(memStream.GetBuffer(), 0, CInt(Fix(fileStream.Length)))
            End Using

            If File.Exists(Server.MapPath("~/DownloadCSV/DownloadAgentsData.csv")) Then
                File.Delete(Server.MapPath("~/DownloadCSV/DownloadAgentsData.csv"))
            End If

            Response.Clear()
            Response.ContentType = "application/force-download"
            Response.AddHeader("content-disposition", "attachment; filename=DownloadAgentsData.csv")
            Response.Buffer = True
            Dim bytes = memStream.ToArray()
            Response.OutputStream.Write(bytes, 0, bytes.Length)
            Response.OutputStream.Flush()
            Response.End()
        Catch ex As Exception
            HttpContext.Current.Trace.Warn("Exception message:  ::", ex.Message)
            HttpContext.Current.Trace.Warn("Error Stack Trace ::", ex.StackTrace)
        End Try
    End Sub

    Protected Sub BUT_Download_BaggageAndTaxis_Data_Click(sender As Object, e As System.EventArgs) Handles BUT_Download_BaggageAndTaxis_Data.Click
        Try
            Dim intCompanyId As Integer = objFunction.ReturnInteger(Session("CompanyId"))
            Dim dstData As DataSet = (New clsDLExtra()).GetExtraDetailFillInDD(intCompanyId)

            If File.Exists(Server.MapPath("~/DownloadCSV/DownloadBaggageAndTaxisData.csv")) Then
                File.Delete(Server.MapPath("~/DownloadCSV/DownloadBaggageAndTaxisData.csv"))
            End If

            Dim strFilePath As String = Server.MapPath("~/DownloadCSV/DownloadBaggageAndTaxisData.csv")
            Dim objStreamWriter As IO.StreamWriter = My.Computer.FileSystem.OpenTextFileWriter(strFilePath, True)

            Dim strHeaderLine As String
            strHeaderLine = "Accom Name," + "Contact," + "Email"
            objStreamWriter.WriteLine(strHeaderLine)

            If objFunction.CheckDataSet(dstData) Then
                For i = 0 To dstData.Tables(0).Rows.Count - 1
                    Dim strFileData As String = objFunction.ReturnString(dstData.Tables(0).Rows(i)("name")).Replace(",", " ") + "," +
                                                objFunction.ReturnString(dstData.Tables(0).Rows(i)("contact")).Replace(",", " ") + "," +
                                                objFunction.ReturnString(dstData.Tables(0).Rows(i)("email"))
                    objStreamWriter.WriteLine(strFileData)
                Next
            End If

            objStreamWriter.Close()

            Dim memStream As New MemoryStream()
            Using fileStream As FileStream = File.OpenRead(Server.MapPath("~/DownloadCSV/DownloadBaggageAndTaxisData.csv"))
                memStream.SetLength(fileStream.Length)
                fileStream.Read(memStream.GetBuffer(), 0, CInt(Fix(fileStream.Length)))
            End Using

            If File.Exists(Server.MapPath("~/DownloadCSV/DownloadBaggageAndTaxisData.csv")) Then
                File.Delete(Server.MapPath("~/DownloadCSV/DownloadBaggageAndTaxisData.csv"))
            End If

            Response.Clear()
            Response.ContentType = "application/force-download"
            Response.AddHeader("content-disposition", "attachment; filename=DownloadBaggageAndTaxisData.csv")
            Response.Buffer = True
            Dim bytes = memStream.ToArray()
            Response.OutputStream.Write(bytes, 0, bytes.Length)
            Response.OutputStream.Flush()
            Response.End()
        Catch ex As Exception
            HttpContext.Current.Trace.Warn("Exception message:  ::", ex.Message)
            HttpContext.Current.Trace.Warn("Error Stack Trace ::", ex.StackTrace)
        End Try
    End Sub
End Class





