
<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="BankAccountingSetupList.aspx.cs" Inherits="System_Settings_BankAccountingSetupList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
    <script src="../infra_ui/js/System_Settings_JS/BankAccountingSetupList.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="PageContent" Runat="Server">
    <div id="content" class="ui-content ui-content-aside-overlay">
        <!--page header start-->
        <div class="page-head-wrap">
            <div class="row">
                <div class="btn-group col-md-12 col-xs-12 pull-left" role="group">
                    <asp:Button runat="server" ID="btnNew" CssClass="btn btn-success" Text="<%$ Resources:GlobalResource, btnNew%>" OnClick="btnNew_Click" />
                    <asp:Button runat="server" ID="btnDelete" CssClass="btn btn-success" Text="<%$ Resources:GlobalResource, btnDelete%>" OnClick="btnDelete_Click" />
                      <asp:LinkButton runat="server" ID="lnkExportToExcel" OnClick="lnkExportToExcel_Click" CssClass="btn btn-success">
                           <asp:Literal runat="server" ID="ltrExportToExcel" Text="<%$Resources:GlobalResource, ltrExportToExcel%>"></asp:Literal>
                            </asp:LinkButton>
                    <asp:UpdatePanel runat="server" ID="updpnlMainSearch">
                        <ContentTemplate>
                            <asp:Panel runat="server" ID="pnlMainSearch" DefaultButton="btnMainSearch">
                                <div class="col-md-4 col-xs-5">
                                    <div class="icon-addon addon-md">
                                        <asp:TextBox runat="server" ID="txtSearch" CssClass="form-control" placeholder="Search..." autofocus="autofocus"></asp:TextBox>
                                        <a runat="server" id="btnHtmlSearch" onclick="CallMainSearch();" class="fa fa-search"></a>
                                        <a runat="server" id="btnHtmlClose" visible="false" onclick="ClearMainSearch();" class="fa fa-close closex"></a>
                                    </div>
                                </div>
                                <asp:Button runat="server" ID="btnMainSearch" Style="display: none;" ClientIDMode="Static" OnClick="btnMainSearch_Click" />
                                <asp:Button runat="server" ID="btnClearMainSearch" Style="display: none;" ClientIDMode="Static" OnClick="btnClearMainSearch_Click" />
                            </asp:Panel>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </div>
            </div>
        </div>

        <div class="ui-content-body">
            <div class="ui-container">
                <div class="row">
                    <h3 class="hepad">
                        <asp:Literal runat="server" ID="ltrSearch" Text="<%$ Resources:GlobalResource, BankAccountingSetup_ltrBankAccountingSetupDetails %>"></asp:Literal></h3>
                    <div class="col-md-12 col-sm-12 colformstyle3">
                        <div runat="server" id="divError" visible="false" class="alert alert-danger" role="alert">
                            <asp:Label runat="server" ID="lblError"></asp:Label>
                        </div>
                        <div runat="server" id="divSuccess" visible="false" class="alert alert-success" role="alert">
                            <asp:Label runat="server" ID="lblSuccess"></asp:Label>
                        </div>
                        <asp:UpdatePanel runat="server" ID="updPanelData">
                            <ContentTemplate>

                                <asp:DataGrid runat="server" ClientIDMode="Static" Font-Size="10pt" ID="gvData" AutoGenerateColumns="false" Width="100%" GridLines="None" BorderStyle="None" CssClass="table table-hover">
                                    <Columns>
                                        <asp:TemplateColumn>
                                            <ItemTemplate>
                                                <asp:CheckBox ID="chkRow" runat="server" />
                                            </ItemTemplate>
                                        </asp:TemplateColumn>
                                        <asp:BoundColumn DataField="tbl_BankAccountingSetupId" Visible="false"></asp:BoundColumn>

                                        <asp:BoundColumn HeaderText="<%$ Resources:GlobalResource, BankAccountingSetup_htDepositcode%>" DataField="Depositcode"></asp:BoundColumn>
                                        <asp:BoundColumn HeaderText="<%$ Resources:GlobalResource, BankAccountingSetup_htDeposit%>" DataField="Deposit"></asp:BoundColumn>
                                        <asp:BoundColumn HeaderText="<%$ Resources:GlobalResource, BankAccountingSetup_htReceiptCode%>" DataField="ReceiptCode"></asp:BoundColumn>
                                        <asp:BoundColumn HeaderText="<%$ Resources:GlobalResource, BankAccountingSetup_htReceipt%>" DataField="Receipt"></asp:BoundColumn>
                                         <asp:BoundColumn HeaderText="<%$ Resources:GlobalResource, BankAccountingSetup_htChequeBookName%>" DataField="ChequeBookName"></asp:BoundColumn>
                                        <asp:BoundColumn HeaderText="<%$ Resources:GlobalResource, BankAccountingSetup_htCheckCode%>" DataField="CheckCode"></asp:BoundColumn>
                                        <asp:BoundColumn HeaderText="<%$ Resources:GlobalResource, BankAccountingSetup_htCheck%>" DataField="Check"></asp:BoundColumn>
                                      
                                  
                                        <asp:TemplateColumn HeaderImageUrl="~/images/eye.png" HeaderStyle-HorizontalAlign="Center">
                                            <ItemTemplate>
                                                <button id="lnkView_<%# Container.DataSetIndex + 1 %>" type="button" data-toggle="modal" data-target="#divBasicModal" data-keyboard="false" data-backdrop="static" class="btn btn-default btn-sm btn-block" onclick="setDetails('<%#Eval("Depositcode")%>', '<%#Eval("Deposit")%>', '<%#Eval("ReceiptCode")%>','<%#Eval("Receipt")%>','<%#Eval("CheckCode")%>','<%#Eval("Check")%>','<%#Eval("WithdrawalCode")%>','<%#Eval("Withdrawal")%>','<%#Eval("IncreaseAdjustmentCode")%>','<%#Eval("IncreaseAdjustment")%>','<%#Eval("DecreaseAdjustmentCode")%>','<%#Eval("DecreaseAdjustment")%>','lnkview_<%# Container.DataSetIndex + 1 %>');">
                                                    <asp:Literal runat="server" ID="ltrView" Text="<%$ Resources:GlobalResource, ltrView%>"></asp:Literal></button>
                                                <button id="lnkViewNextPrev_<%# Container.DataSetIndex + 1 %>" style="display: none;" type="button" class="btn btn-default btn-sm" onclick="setDetails('<%#Eval("Depositcode")%>', '<%#Eval("Deposit")%>', '<%#Eval("ReceiptCode")%>','<%#Eval("Receipt")%>','<%#Eval("CheckCode")%>','<%#Eval("Check")%>','<%#Eval("WithdrawalCode")%>','<%#Eval("Withdrawal")%>','<%#Eval("IncreaseAdjustmentCode")%>','<%#Eval("IncreaseAdjustment")%>','<%#Eval("DecreaseAdjustmentCode")%>','<%#Eval("DecreaseAdjustment")%>','lnkview_<%# Container.DataSetIndex + 1 %>');"></button>
                                            </ItemTemplate>
                                        </asp:TemplateColumn>

                                        <asp:TemplateColumn HeaderImageUrl="~/images/edit.png" HeaderStyle-HorizontalAlign="Center">
                                            <ItemTemplate>
                                                <asp:LinkButton runat="server" ID="gvColLnkBtn" class="btn btn-default btn-sm btn-block" OnClick="gvColLnkBtn_Click" CommandArgument='<%#Eval("tbl_BankAccountingSetupId") %>'>
                                                    <asp:Literal runat="server" ID="ltrEdit" Text="<%$ Resources:GlobalResource, ltrEdit%>"></asp:Literal>
                                                </asp:LinkButton>
                                            </ItemTemplate>
                                        </asp:TemplateColumn>
                                    </Columns>
                                    <HeaderStyle BackColor="#24648f" ForeColor="White" />
                                </asp:DataGrid>
                            </ContentTemplate>
                            <Triggers>
                                <asp:AsyncPostBackTrigger EventName="Click" ControlID="btnMainSearch" />
                                <asp:AsyncPostBackTrigger EventName="Click" ControlID="btnClearMainSearch" />
                            </Triggers>
                        </asp:UpdatePanel>
                    </div>
                </div>
            </div>
        </div>
    </div>

    <div class="modal fade" id="divBasicModal" tabindex="-1" role="dialog" aria-labelledby="basicModal" aria-hidden="true">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header" style="text-align: left;">
                    <button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>
                    <h4 class="modal-title" id="myModalLabel"><span>
                        <asp:Literal runat="server" ID="ltrRecordDetails" Text="<%$ Resources:GlobalResource, BankAccountingSetup_ltrBankAccountingSetupListDetails %>"></asp:Literal></span></h4>
                </div>
                <div class="modal-body">
                    <table class="table table-striped" style="width: 100%; font-size: 9.5pt;">
                        <tr>
                            <td class="auto-style1">
                                <asp:Literal runat="server" ID="ltrDepositcode" Text="<%$ Resources:GlobalResource, BankAccountingSetup_ltrDepositcode%>"></asp:Literal></td>
                            <td class="auto-style1">
                                <asp:Literal runat="server" ID="ltrDeposit" Text="<%$ Resources:GlobalResource, BankAccountingSetup_ltrDeposit%>"></asp:Literal></td>
                            <td class="auto-style1">
                                <asp:Literal runat="server" ID="ltrReceiptCode" Text="<%$ Resources:GlobalResource, BankAccountingSetup_ltrReceiptCode%>"></asp:Literal></td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="lblDepositcode" runat="server" ClientIDMode="Static"></asp:Label></td>
                            <td>
                                <asp:Label ID="lblDeposit" runat="server" ClientIDMode="Static"></asp:Label></td>
                            <td>
                                <asp:Label ID="lblReceiptCode" runat="server" ClientIDMode="Static"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td class="auto-style1">
                                <asp:Literal runat="server" ID="ltrReceipt" Text="<%$ Resources:GlobalResource, BankAccountingSetup_ltrReceipt%>"></asp:Literal></td>
                            <td class="auto-style1">
                                <asp:Literal runat="server" ID="ltrCheckCode" Text="<%$ Resources:GlobalResource, BankAccountingSetup_ltrCheckCode%>"></asp:Literal></td>
                            <td class="auto-style1">
                                <asp:Literal runat="server" ID="ltrCheck" Text="<%$ Resources:GlobalResource, BankAccountingSetup_ltrCheck%>"></asp:Literal></td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="lblReceipt" runat="server" ClientIDMode="Static"></asp:Label></td>
                            <td>
                                <asp:Label ID="lblCheckCode" runat="server" ClientIDMode="Static"></asp:Label></td>
                            <td>
                                <asp:Label ID="lblCheck" runat="server" ClientIDMode="Static"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td class="auto-style1">
                                <asp:Literal runat="server" ID="ltrWithdrawalCode" Text="<%$ Resources:GlobalResource, BankAccountingSetup_ltrWithdrawalCode%>"></asp:Literal></td>
                            <td class="auto-style1">
                                <asp:Literal runat="server" ID="ltrWithdrawal" Text="<%$ Resources:GlobalResource, BankAccountingSetup_ltrWithdrawal%>"></asp:Literal></td>
                            <td class="auto-style1">
                                <asp:Literal runat="server" ID="ltrIncreaseAdjustmentCode" Text="<%$ Resources:GlobalResource, BankAccountingSetup_ltrIncreaseAdjustmentCode%>"></asp:Literal></td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="lblWithdrawalCode" runat="server" ClientIDMode="Static"></asp:Label></td>
                            <td>
                                <asp:Label ID="lblWithdrawal" runat="server" ClientIDMode="Static"></asp:Label></td>
                            <td>
                                <asp:Label ID="lblIncreaseAdjustmentCode" runat="server" ClientIDMode="Static"></asp:Label>
                            </td>
                        </tr>

                        <tr>
                            <td class="auto-style1">
                                <asp:Literal runat="server" ID="ltrIncreaseAdjustment" Text="<%$ Resources:GlobalResource, BankAccountingSetup_ltrIncreaseAdjustment%>"></asp:Literal>

                            </td>
                             <td class="auto-style1">
                                <asp:Literal runat="server" ID="ltrDecreaseAdjustmentCode" Text="<%$ Resources:GlobalResource, BankAccountingSetup_ltrDecreaseAdjustmentCode%>"></asp:Literal>

                            </td>
                             <td class="auto-style1">
                                <asp:Literal runat="server" ID="ltrDecreaseAdjustment" Text="<%$ Resources:GlobalResource, BankAccountingSetup_ltrDecreaseAdjustment%>"></asp:Literal>

                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="lblIncreaseAdjustment" runat="server" ClientIDMode="Static"></asp:Label></td>
                             <td>
                                <asp:Label ID="lblDecreaseAdjustmentCode" runat="server" ClientIDMode="Static"></asp:Label></td>
                             <td>
                                <asp:Label ID="lblDecreaseAdjustment" runat="server" ClientIDMode="Static"></asp:Label></td>
                        </tr>
                    </table>
                </div>
                <div class="modal-footer row" runat="server" id="divFooter">
                    <div class="btn-group pull-right" role="group" aria-label="...">
                        <a id="btnPrevious" class="btn btn-default" role="button" onclick="showPrevRecord();"><i class="fa fa-chevron-circle-left"></i>
                            <asp:Literal runat="server" ID="ltrPrevious" Text="<%$ Resources:GlobalResource, btnPrevious%>"></asp:Literal></a>
                        <a id="btnNext" class="btn btn-default" role="button" onclick="showNextRecord();">
                            <asp:Literal runat="server" ID="ltrNext" Text="<%$ Resources:GlobalResource, btnNext%>"></asp:Literal>
                            <i class="fa fa-chevron-circle-right"></i></a>
                    </div>
                    <asp:Label ID="lblGvRowId" runat="server" Style="display: none;" ClientIDMode="Static"></asp:Label>
                    <div class="pull-left">
                        <button type="button" class="btn btn-default" data-dismiss="modal">
                            <asp:Literal runat="server" ID="ltrClose" Text="<%$ Resources:GlobalResource, ltrClose%>"></asp:Literal></button>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>

