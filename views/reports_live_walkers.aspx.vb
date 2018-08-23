Imports System.Data
Imports Easyway.BE
Imports Easyway.DL

Partial Class reports_live_walkers
    Inherits System.Web.UI.Page

    Dim objFunction As New clsCommon()
    
    ''' <summary>
    ''' Load event of the page
    ''' </summary>
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Try
            If Not objFunction.ValidateLogin() Then
                Response.Redirect("~/login.aspx")
            End If

            If Not Page.IsPostBack Then

                Trace.Warn("Session = " + Session("feedback_call"))
                If Session("feedback_call") <> "" And objFunction.ReturnInteger(Session("feedback_call")) = 1 Then
                    Me.Master.show_feedback_layer(objFunction.ReturnInteger(Session("feedback_call")), objFunction.ReturnString(Session("error_msg")))
                ElseIf Session("feedback_call") <> "" And objFunction.ReturnInteger(Session("feedback_call")) = 2 Then
                    Me.Master.show_feedback_layer(objFunction.ReturnInteger(Session("feedback_call")), objFunction.ReturnString(Session("error_msg")))
                End If
                Session("feedback_call") = "0"
                Session("error_msg") = ""
                Trace.Warn("End Session = " + Session("feedback_call"))

                Dim intCompanyId = objFunction.ReturnInteger(Session("CompanyId"))
                Dim dstRoute As DataSet = (New clsDLRoute()).GetRouteFillInDD(intCompanyId)
                objFunction.FillDropDownByDataSet(DROP_Route, dstRoute)
                DROP_Route.Items.Insert(0, New ListItem("All", "0"))

                Dim dstStage As DataSet = (New clsDLStages()).GetStagesFillInDD(intCompanyId)
                objFunction.FillDropDownByDataSet(DROP_Stage, dstStage)
                DROP_Stage.Items.Insert(0, New ListItem("All", "0"))

                Dim dstAccomodation As DataSet = (New clsDLAccomodation()).GetAccommodationDetailFillInDD(intCompanyId)
                objFunction.FillDropDownByDataSet(DROP_Accom, dstAccomodation)
                DROP_Accom.Items.Insert(0, New ListItem("All", "0"))

            End If

        Catch ex As Exception
            HttpContext.Current.Trace.Warn("Exception message:  ::", ex.Message)
            HttpContext.Current.Trace.Warn("Error Stack Trace ::", ex.StackTrace)
        End Try

    End Sub

    ''' <summary>
    ''' This function is used to bind gridview
    ''' </summary>
    Protected Sub BindGridview()

        Try
            Dim intCompanyId = objFunction.ReturnInteger(Session("CompanyId"))

            Dim strSearchByFromDate As String = ""
            If TB_Date_From.Text <> "" Then
                Dim dt As DateTime = (If(TB_Date_From.Text <> "", Convert.ToDateTime(TB_Date_From.Text), DateTime.MinValue))
                strSearchByFromDate = dt.ToString("MM-dd-yyyy")
            End If

            Dim strSearchByToDate As String = ""
            If TB_Date_To.Text <> "" Then
                Dim dt As DateTime = (If(TB_Date_To.Text <> "", Convert.ToDateTime(TB_Date_To.Text), DateTime.MinValue))
                strSearchByToDate = dt.ToString("MM-dd-yyyy")
            End If

            Dim strSearchByRoute As String = objFunction.ReturnString(DROP_Route.SelectedItem.Value)
            Dim strSearchByStage As String = objFunction.ReturnString(DROP_Stage.SelectedItem.Value)
            Dim strSearchByAccom As String = objFunction.ReturnString(DROP_Accom.SelectedItem.Value)

            Dim dstReportLiveWalkers As DataSet = (New clsDLBookingReport()).GetReportLiveWalkers(intCompanyId, strSearchByFromDate, strSearchByToDate, strSearchByRoute, strSearchByStage, strSearchByAccom)
            GRID_Live_Walkers.DataSource = dstReportLiveWalkers
            GRID_Live_Walkers.DataBind()

            For i As Integer = 0 To GRID_Live_Walkers.Rows.Count - 1
                Dim intCurrentIndex As Integer = (GRID_Live_Walkers.PageSize * GRID_Live_Walkers.PageIndex) + i
                Dim gRow As GridViewRow = GRID_Live_Walkers.Rows(i)
                Dim chkCancelled = DirectCast(gRow.FindControl("CHK_Cancelled"), CheckBox)
                If chkCancelled IsNot Nothing Then
                    Dim bnlChkVal As Boolean = Convert.ToBoolean(dstReportLiveWalkers.Tables(0).Rows(intCurrentIndex)("cancelled"))
                    If bnlChkVal = True Then
                        chkCancelled.Checked = True
                    End If
                End If

                Dim lblRooms = DirectCast(gRow.FindControl("LABEL_Rooms"), Label)
                Dim intBookingId As Integer = objFunction.ReturnInteger(dstReportLiveWalkers.Tables(0).Rows(intCurrentIndex)("id"))
                Dim intAccomStageId As Integer = objFunction.ReturnInteger(dstReportLiveWalkers.Tables(0).Rows(intCurrentIndex)("AccomStageId"))
                Dim dstAccomStageRoom As DataSet = (New clsDLAccomStageRoom()).GetAccomStageRoomRoomTypeNameByBookingId(intBookingId, intAccomStageId)
                If objFunction.CheckDataSet(dstAccomStageRoom) Then
                    Dim strRoomTypeName As String = ""
                    For j = 0 To dstAccomStageRoom.Tables(0).Rows.Count - 1
                        strRoomTypeName += objFunction.ReturnString(dstAccomStageRoom.Tables(0).Rows(j)("name")) + ","
                    Next
                    lblRooms.Text = strRoomTypeName.TrimEnd(",")
                End If
            Next

        Catch ex As Exception
            HttpContext.Current.Trace.Warn("Exception message:  ::", ex.Message)
            HttpContext.Current.Trace.Warn("Error Stack Trace ::", ex.StackTrace)
        End Try

    End Sub

    ''' <summary>
    ''' PageIndexChanging event of the GRID_Live_Walkers
    ''' </summary>
    Protected Sub GRID_Live_Walkers_PageIndexChanging(ByVal sender As Object, ByVal e As GridViewPageEventArgs)

        Try
            GRID_Live_Walkers.PageIndex = e.NewPageIndex
            BindGridview()
        Catch ex As Exception
            HttpContext.Current.Trace.Warn("Exception message:  ::", ex.Message)
            HttpContext.Current.Trace.Warn("Error Stack Trace ::", ex.StackTrace)
        End Try

    End Sub

    ''' <summary>
    ''' SelectedIndexChanged event of the GRID_Live_Walkers
    ''' </summary>
    Protected Sub GRID_Live_Walkers_SelectedIndexChanged(ByVal sender As Object, ByVal e As GridViewSelectEventArgs)
        Try
            'Trace.Warn("Value = " + objFunction.ReturnString(GRID_Live_Walkers.DataKeys(e.NewSelectedIndex).Value))
            Session("BookingId") = objFunction.ReturnString(GRID_Live_Walkers.DataKeys(e.NewSelectedIndex).Value)
            'Response.Redirect("bookings_view.aspx")
            Dim strUrl = "bookings_view.aspx"
            Response.Write("<script>")
            Response.Write("window.open('" + strUrl + "','_blank')")
            Response.Write("</script>")
        Catch ex As Exception
            HttpContext.Current.Trace.Warn("Exception message:  ::", ex.Message)
            HttpContext.Current.Trace.Warn("Error Stack Trace ::", ex.StackTrace)
        End Try
    End Sub

    ''' <summary>
    ''' Clieck event of button to get record
    ''' </summary>
    Protected Sub BUT__View_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BUT__View.Click
        Try
            BindGridview()
        Catch ex As Exception
            HttpContext.Current.Trace.Warn("Exception message:  ::", ex.Message)
            HttpContext.Current.Trace.Warn("Error Stack Trace ::", ex.StackTrace)
        End Try
    End Sub

    ''' <summary>
    ''' This function is used to set date value
    ''' </summary>
    Public Function SetDateVal(ByVal value As Object) As String
        Try
            If objFunction.ReturnString(value) <> "" Then
                Dim dt As DateTime = Convert.ToDateTime(value)
                Return dt.ToString("dd/MM/yyyy")
            Else
                Return ""
            End If
        Catch ex As Exception
            HttpContext.Current.Trace.Warn("Exception message:  ::", ex.Message)
            HttpContext.Current.Trace.Warn("Error Stack Trace ::", ex.StackTrace)
        End Try
        Return ""
    End Function

End Class