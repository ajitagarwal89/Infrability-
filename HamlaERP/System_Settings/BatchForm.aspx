<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="BatchForm.aspx.cs" Inherits="System_Settings_BatchForm" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">    
    <script src="../infra_ui/js/System_Settings_JS/BatchForm.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="PageContent" runat="Server">
    <div id="content" class="ui-content ui-content-aside-overlay">
        <!--page header start-->
        <div id="ButtonBar" class="page-head-wrap">
            <div class="row">
                <div class="btn-group col-md-12 col-xs-12 pull-left" role="group">
                    <asp:Button runat="server" ID="btnSave" CssClass="btn btn-success" OnClick="btnSave_Click" Text="<%$ Resources:GlobalResource, btnSave%>" />
                    <asp:Button runat="server" ID="btnUpdate" CssClass="btn btn-success" OnClick="btnUpdate_Click" Text="<%$ Resources:GlobalResource, btnUpdate%>" />
                    <asp:Button runat="server" ID="btnDelete" CssClass="btn btn-success" OnClick="btnDelete_Click" Text="<%$ Resources:GlobalResource, btnDelete%>" />
                    <asp:Button runat="server" ID="btnBack" CssClass="btn btn-success" OnClick="btnBack_Click" Text="<%$ Resources:GlobalResource, btnBack%>" formnovalidate="formnovalidate" ></asp:Button>
                    <asp:Button runat="server" ID="btnClear" CssClass="btn btn-success" OnClientClick="return ClearForm();" Text="<%$ Resources:GlobalResource, btnClear%>" formnovalidate="formnovalidate" ></asp:Button>
                </div>
            </div>
        </div>

        <div class="ui-content-body">
            <div class="ui-container">
                <div class="row">
                    <h3 class="hepad">
                        <asp:Label runat="server" ID="lblHeading"></asp:Label></h3>
                    <div class="col-md-12 col-sm-12 colformstyle">
                        <div runat="server" id="divError" visible="false" class="alert alert-danger" role="alert">
                            <asp:Label runat="server" ID="lblError"></asp:Label>
                        </div>
                        <div runat="server" id="divSuccess" visible="false" class="alert alert-success" role="alert">
                            <asp:Label runat="server" ID="lblSuccess"></asp:Label>
                        </div>
                        <div class="form-group col-md-12" style="background-color: #f6f6f6">
                            <h5>
                                <asp:Literal runat="server" ID="ltrBatchInformation" Text="<%$ Resources:GlobalResource, Batch_ltrInformation%>"></asp:Literal></h5>
                        </div>
                      
                        <div class="form-group col-md-4 col-sm-4">
                            <asp:Label runat="server" ID="lblOpt_BatchType"  Text="<%$ Resources:GlobalResource, Batch_lblBatchType %>"></asp:Label>
                            <asp:DropDownList ID="ddlOpt_BatchType" runat="server" ClientIDMode="Static" class="form-control" placeholder="" required="required">
                            </asp:DropDownList>


                        </div>
                        <div class="form-group col-md-4 col-sm-4">
                            <asp:Label runat="server" ID="lblBatchName"  Text="<%$ Resources:GlobalResource, Batch_lblBatchName %>"></asp:Label>
                            <asp:TextBox type="text" runat="server" ID="txtBatchName" ClientIDMode="Static" class="form-control" placeholder="" required="required"></asp:TextBox>

                        </div>
                        <div class="form-group col-md-4 col-sm-4">
                            <asp:Label runat="server" ID="lblComment"  Text="<%$ Resources:GlobalResource, Batch_lblComment %>">></asp:Label>
                            <asp:TextBox type="text" runat="server" ID="txtComment" TextMode="MultiLine" ClientIDMode="Static" class="form-control" placeholder="" required="required"></asp:TextBox>
                        </div>

                        <div class="form-group col-md-4 col-sm-4">
                            <asp:Label runat="server" ID="lblOpt_Origin"  Text="<%$ Resources:GlobalResource, Batch_lblOrigin %>"></asp:Label>
                            <asp:DropDownList ID="ddlOpt_Origin" runat="server" ClientIDMode="Static" class="form-control" placeholder="" required="required">
                            </asp:DropDownList>
                        </div>

                        <div class="form-group col-md-4 col-sm-4">
                            <asp:Label runat="server" ID="lblDatePosted" Text="<%$ Resources:GlobalResource, Batch_lblDatePosted %>"></asp:Label>
                            <asp:TextBox type="text" runat="server" ID="txtPostingDate" TextMode="Date" ClientIDMode="Static" class="form-control" placeholder="" required="required"></asp:TextBox>


                        </div>

                        <div class="form-group col-md-4 col-sm-4">
                            <asp:Label runat="server" ID="lblOpt_Frequency" Text="<%$ Resources:GlobalResource, Btach_lblFrequency %>" ></asp:Label>
                            <asp:DropDownList ID="ddlOpt_Frequency" runat="server" ClientIDMode="Static" class="form-control" placeholder="" required="required">
                            </asp:DropDownList>


                        </div>

                        <div class="form-group col-md-4 col-sm-4">
                            <asp:Label runat="server" ID="lblBreakDownAllocation" Text="<%$ Resources:GlobalResource, Batch_lblBreakDownAllocation %>"></asp:Label>
                            <asp:CheckBox ID="chkBreakDownAllocation" runat="server" ClientIDMode="Static" class="form-control" placeholder="" required="required" />

                        </div>
                        <div class="form-group col-md-4 col-sm-4">
                            <asp:Label runat="server" ID="lblRecurringPosting" Text="<%$ Resources:GlobalResource, Batch_lblRecurringPosting %>"></asp:Label>
                            <asp:TextBox type="text" runat="server" ID="txtRecurringPosting" ClientIDMode="Static" class="form-control" placeholder="" required="required"></asp:TextBox>
                        </div>

                        <div class="form-group col-md-4 col-sm-4">
                            <asp:Label runat="server" ID="lblDaysToIncrement"  Text="<%$ Resources:GlobalResource, Batch_lblDaysToIncrement %>" ></asp:Label>
                            <asp:TextBox type="text" runat="server" ID="txtDaysToIncrement" ClientIDMode="Static" class="form-control" placeholder="" required="required"></asp:TextBox>
                        </div>


                        <div class="form-group col-md-4 col-sm-4">
                            <asp:Label runat="server" ID="lblLastDatePosted" Text="<%$ Resources:GlobalResource, Batch_lblLastDatePosted %>"  ></asp:Label>
                            <asp:TextBox type="text" runat="server" ID="txtLastDatePosted" TextMode="Date" ClientIDMode="Static" class="form-control" placeholder="" required="required"></asp:TextBox>


                        </div>
                        <div class="form-group col-md-4 col-sm-4">
                            <asp:Label runat="server" ID="lblNumberOfDaysPosted" Text="<%$ Resources:GlobalResource, Batch_lblNumberOfDays %>"  ></asp:Label>
                            <asp:TextBox type="text" runat="server" ID="txtNumberOfdays" ClientIDMode="Static" class="form-control" placeholder="" required="required"></asp:TextBox>


                        </div>

                        <div class="form-group col-md-4 col-sm-4">
                            <asp:Label runat="server" ID="lblJournalEntries" Text="<%$ Resources:GlobalResource, Batch_lblJournalEntries %>"></asp:Label>
                            <asp:TextBox type="text" runat="server" ID="txtJournalEntries" ClientIDMode="Static" class="form-control " placeholder="" required="required"></asp:TextBox>
                        </div>

                        <div class="form-group col-md-4 col-sm-4">
                            <asp:Label runat="server" ID="lblActualJournalEntries" Text="<%$ Resources:GlobalResource, Batch_lblActualJournalEntries %>"></asp:Label>
                            <asp:TextBox type="text" runat="server" ID="txtActualJournalEntries" ClientIDMode="Static" class="form-control" placeholder="" required="required"></asp:TextBox>
                        </div>
                        <div class="form-group col-md-4 col-sm-4">
                            <asp:Label runat="server" ID="lblIsApproved" Text="<%$ Resources:GlobalResource, Batch_lblIsApproved %>"></asp:Label>
                          
                            <asp:CheckBox ID="chkIsApproved" runat="server" ClientIDMode="Static" class="form-control" placeholder="" required="required"/>

                        </div>



                    </div>
                </div>
            </div>
        </div>
    </div>

</asp:Content>
