Imports System.Data
Imports Easyway.BE
Imports Easyway.DL

Partial Class booking_options_fee
    Inherits System.Web.UI.Page

    Dim objFunction As New clsCommon()
    Dim objBEBookingFee As clsBEBookingFee = New clsBEBookingFee
    Dim objDLBookingFee As clsDLBookingFee = New clsDLBookingFee

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

                BindGridview()

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
            Dim dstBookingFee As New DataSet()
            dstBookingFee = (New clsDLBookingFee()).GetBookingFee(intCompanyId)
            GridView1.DataSource = dstBookingFee
            GridView1.DataBind()
        Catch ex As Exception
            HttpContext.Current.Trace.Warn("Exception message:  ::", ex.Message)
            HttpContext.Current.Trace.Warn("Error Stack Trace ::", ex.StackTrace)
        End Try

    End Sub

    ''' <summary>
    ''' RowEditing event of the GridView1
    ''' </summary>
    Protected Sub GridView1_RowEditing(ByVal sender As Object, ByVal e As GridViewEditEventArgs)

        Try
            GridView1.EditIndex = e.NewEditIndex
            BindGridview()
        Catch ex As Exception
            HttpContext.Current.Trace.Warn("Exception message:  ::", ex.Message)
            HttpContext.Current.Trace.Warn("Error Stack Trace ::", ex.StackTrace)
        End Try

    End Sub

    ''' <summary>
    ''' RowCancelingEdit event of the GridView1
    ''' </summary>
    Protected Sub GridView1_RowCancelingEdit(ByVal sender As Object, ByVal e As GridViewCancelEditEventArgs)

        Try
            GridView1.EditIndex = -1
            BindGridview()
        Catch ex As Exception
            HttpContext.Current.Trace.Warn("Exception message:  ::", ex.Message)
            HttpContext.Current.Trace.Warn("Error Stack Trace ::", ex.StackTrace)
        End Try

    End Sub

    ''' <summary>
    ''' PageIndexChanging event of the GridView1
    ''' </summary>
    Protected Sub GridView1_PageIndexChanging(ByVal sender As Object, ByVal e As GridViewPageEventArgs)

        Try
            GridView1.PageIndex = e.NewPageIndex
            BindGridview()
        Catch ex As Exception
            HttpContext.Current.Trace.Warn("Exception message:  ::", ex.Message)
            HttpContext.Current.Trace.Warn("Error Stack Trace ::", ex.StackTrace)
        End Try

    End Sub

    ''' <summary>
    ''' RowUpdating event of the GridView1
    ''' </summary>
    Protected Sub GridView1_RowUpdating(ByVal sender As Object, ByVal e As GridViewUpdateEventArgs)

        Try
            Dim id As Integer = objFunction.ReturnInteger(objFunction.ReturnString(GridView1.DataKeys(e.RowIndex).Values("id")))
            Dim txtFeeTotal As TextBox = DirectCast(GridView1.Rows(e.RowIndex).FindControl("TB_FeeTotal"), TextBox)

            If IsNumeric(txtFeeTotal.Text) Then
                objBEBookingFee.BookingFeeId = id
                objBEBookingFee.FeeTotal = objFunction.ReturnDouble(txtFeeTotal.Text)
                objBEBookingFee.CompanyId = objFunction.ReturnString(Session("CompanyId"))

                Dim dstCheckDuplicateRecord As DataSet = objDLBookingFee.CheckDuplicateRecord(objBEBookingFee)

                If objFunction.CheckDataSet(dstCheckDuplicateRecord) Then
                    Session("feedback_call") = "2"
                    Session("error_msg") = "Booking fee for that number of people has already been set. No record has been added."
                Else
                    Dim intAffectedRow As Integer = objDLBookingFee.PerformGridViewOpertaion("UPDATE", objBEBookingFee)
                    If intAffectedRow > 0 Then
                        'Add Activity - Start
                        Dim objBEActivity As New clsBEActivity
                        objBEActivity.Descx = "Booking fee has been amended by " + objFunction.ReturnString(Session("LoginUserFirstName"))
                        objBEActivity.StaffId = objFunction.ReturnInteger(Session("LoginUserId"))

                        Dim objDLActivity As New clsDLActivity
                        objDLActivity.AddActivity(objBEActivity)
                        'Add Activity - End
                        Session("feedback_call") = "1"
                        Session("error_msg") = "Booking fee has been amended"
                    Else
                        Session("feedback_call") = "2"
                        Session("error_msg") = "There was a system error. If this error persists please contact technical support."
                    End If
                End If
            Else
                Session("feedback_call") = "2"
                Session("error_msg") = "Please enter numerical values. No records has been added"
            End If
                GridView1.EditIndex = -1
                'BindGridview()
                Response.Redirect("booking_options_fee.aspx", False)
        Catch ex As Exception
            HttpContext.Current.Trace.Warn("Exception message:  ::", ex.Message)
            HttpContext.Current.Trace.Warn("Error Stack Trace ::", ex.StackTrace)
        End Try

    End Sub

    ''' <summary>
    ''' This event is used to add booking fee details
    ''' </summary>
    Protected Sub BUT_Add_Booking_Fee_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BUT_Add_Booking_Fee.Click
        Try
            If IsNumeric(TB_Booking_Total_No_People.Text) And IsNumeric(TB_Booking_Fee_Total.Text) Then
                objBEBookingFee.TotalNum = objFunction.ReturnInteger(TB_Booking_Total_No_People.Text)
                objBEBookingFee.FeeTotal = objFunction.ReturnDouble(TB_Booking_Fee_Total.Text)
                objBEBookingFee.CompanyId = objFunction.ReturnString(Session("CompanyId"))

                Dim dstCheckDuplicateRecord As DataSet = objDLBookingFee.CheckDuplicateRecord(objBEBookingFee)

                If objFunction.CheckDataSet(dstCheckDuplicateRecord) Then
                    Session("feedback_call") = "2"
                    Session("error_msg") = "Booking fee for that number of people has already been set. No record has been added."
                Else
                    Dim intAffectedRow As Integer = objDLBookingFee.AddBookingFee(objBEBookingFee)
                    If intAffectedRow > 0 Then
                        'Add Activity - Start
                        Dim objBEActivity As New clsBEActivity
                        objBEActivity.Descx = "Booking fee has been added by " + objFunction.ReturnString(Session("LoginUserFirstName"))
                        objBEActivity.StaffId = objFunction.ReturnInteger(Session("LoginUserId"))

                        Dim objDLActivity As New clsDLActivity
                        objDLActivity.AddActivity(objBEActivity)
                        'Add Activity - End
                        Session("feedback_call") = "1"
                        Session("error_msg") = "New booking fee has been added"
                        TB_Booking_Total_No_People.Text = ""
                        TB_Booking_Fee_Total.Text = ""
                    Else
                        Session("feedback_call") = "2"
                        Session("error_msg") = "There was a system error. If this error persists please contact technical support."
                    End If
                End If
            Else
                Session("feedback_call") = "2"
                Session("error_msg") = "Please enter numerical values. No records has been added"
            End If
            Response.Redirect("booking_options_fee.aspx", False)
        Catch ex As Exception
            HttpContext.Current.Trace.Warn("Exception message:  ::", ex.Message)
            HttpContext.Current.Trace.Warn("Error Stack Trace ::", ex.StackTrace)
        End Try
    End Sub
End Class





