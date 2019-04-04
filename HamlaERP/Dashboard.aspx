<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="Dashboard.aspx.cs" Inherits="Dashboard" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
    <script src="infra_ui/js/1.8.3.jquery.min.js"></script>
    <script src="infra_ui/js/morris.min.js"></script>
    <script src="infra_ui/js/raphael-2.1.0.min.js"></script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="PageContent" runat="Server">

    <div class="container-fluid">
        <div id="content" class="ui-content ui-content-aside-overlay">
            <div class="ui-content-body">
                <div class="ui-container">
                    <div class="row">
                        <div class="col-md-4"></div>
                        <div class="col-md-4"></div>
                        <div class="col-md-4">
                            <asp:Label runat="server" ID="lblReport" TabIndex="1" Text="<%$ Resources:GlobalResource, Dashboard_lblReport%>"></asp:Label>

                            <asp:DropDownList ID="ddlChart" runat="server" OnLoad="ddlChart_SelectedIndexChanged" ClientIDMode="Static" class="form-control " AutoPostBack="true" placeholder="" required="required" OnSelectedIndexChanged="ddlChart_SelectedIndexChanged">
                                <asp:ListItem Value="downPaymentFromCustomer">DownPaymentFromCustomer  </asp:ListItem>
                                <asp:ListItem Value="downPaymentToSupplier">Down Payment To Supplier</asp:ListItem>
                                <asp:ListItem Value="paymentFromCustomer">Payment From Customer</asp:ListItem>
                                <asp:ListItem Value="paymentToEmployee">Payment To Employee</asp:ListItem>
                                <asp:ListItem Value="paymentToSupplierEmployee">Payment To Supplier Employee</asp:ListItem>
                                <asp:ListItem Value="customerInvoice">Customer Invoice</asp:ListItem>
                                <asp:ListItem Value="customerInvoiceProcess">Customer Invoice Process</asp:ListItem>
                                <asp:ListItem Value="employeeGeneralExpenses">Employee General Expenses</asp:ListItem>
                                <asp:ListItem Value="pOBasedInvoice">POBased Invoice</asp:ListItem>
                                <asp:ListItem Value="paymentToSupplier">Payment To Supplier</asp:ListItem>
                                <asp:ListItem Value="nonPOBasedInvoice">Non POBased Invoice</asp:ListItem>
                                <asp:ListItem Value="supplierEmployeeGeneralExpenses">Supplier Employee General Expenses</asp:ListItem>
                            </asp:DropDownList>

                        </div>
                    </div>
                </div>
            </div>

            <script>
                function openOrganizationSelectModal() {
                    document.getElementById('btnOpenOrganizationModal').click();
                }
            </script>
            <a href="#" id="btnOpenOrganizationModal" class="btn btn-default" data-toggle="modal" data-keyboard="false" data-backdrop="static" data-target="#organizationModal" style="display: none"></a>
            <div class="modal fade" id="organizationModal" tabindex="-1" role="dialog" aria-labelledby="basicModal" aria-hidden="true">
                <div class="modal-dialog">
                    <div class="modal-content">
                        <div class="modal-header" style="text-align: left;">

                            <h4 class="modal-title" id="myModalLabel"> <asp:Literal runat="server" Text="<%$ Resources:GlobalResource, Dashboard_lblOrganization %>"></asp:Literal></h4>
                        </div>
                        <div class="modal-body">
                            <asp:Label runat="server" ID="lblOrganization"  Text="<%$ Resources:GlobalResource, Dashboard_lblOrganization %>" ></asp:Label>
                            <asp:DropDownList runat="server" CssClass="form-control" ID="ddlOrganizationList"></asp:DropDownList><br />
                        </div>
                        <div class="modal-footer row" runat="server" id="div_bk_footer">
                            <div class="pull-right">

                                <div class="pull-right">
                                    <asp:Button runat="server" CssClass="btn btn-default" ID="btnOk" Text="<%$ Resources:GlobalResource, Dashboard_btnOk %>" OnClick="btnOk_Click" formnovalidate="formnovalidate"></asp:Button>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <div class="row contentpadding" style="margin-top: -40px;">
                <!--DownPaymentFromCustomer-->
                <div id="dvdownPaymentFromCustomer" runat="server">
                    <div class="col-sm-12 col-md-4">
                        <div class="panel panel-default">
                            <div class="panel-body">

                                <h5>
                                    <asp:Literal runat="server" Text="<%$ Resources:GlobalResource, Dashboard_Piechart%>"></asp:Literal></h5>

                                <p>
                                    <asp:Literal runat="server" Text="<%$ Resources:GlobalResource,Dashboard_DownPaymentFromCustomer_ChartHeader %>"></asp:Literal>
                                </p>
                                <div id="piechart" style="width: 100%; height: 400px"></div>
                            </div>
                        </div>
                        <script>
                    <%=piechart%>
                            var options = {
                                series: {
                                    pie: {
                                        show: true,
                                        label: {
                                            innerRadius: 0.5,
                                            show: true,
                                            formatter: function (label, series) {

                                                return '<div style="font-size:11px ;text-align:center; padding:2px; color:white;">' + label + '<br/>' + Math.round(series.percent) + '%</div>';
                                            },
                                            background: {
                                                opacity: 0.8,
                                                color: '#000'
                                            }
                                        }
                                    }
                                },
                                legend: {
                                    show: true
                                },
                                grid: {
                                    hoverable: true
                                }
                            };
                            $(document).ready(function () {
                                $.plot($("#piechart"), dataSet, options);
                            });
                        </script>
                    </div>
                    <div class="col-sm-12 col-md-4 mb20">
                        <div class="panel panel-default">
                            <div class="panel-body">

                                <h5>
                                    <asp:Literal runat="server" Text="<%$ Resources:GlobalResource, Dashboard_Stackedchart%>"></asp:Literal></h5>

                                <p>
                                    <asp:Literal runat="server" Text="<%$ Resources:GlobalResource,Dashboard_DownPaymentFromCustomer_ChartHeader %>"></asp:Literal>
                                </p>
                                <div id="stackedChart" class="body-chart"></div>
                            </div>
                        </div>
                        <!-- panel-body -->
                        <style>
                            .morris-hover {
                                position: absolute;
                                z-index: auto;
                                background-color: #fff;
                                opacity: 0.4;
                            }
                        </style>
                        <script>
                            Morris.Bar({
                                element: 'stackedChart',
                                hideHover: 'auto',
                    <%=stackedchart%>
                                xkey: 'x',
                                ykeys: ['y', 'z'],
                                labels: ['Y', 'Z']
                            }).on('click', function (i, row) {
                                console.log(i, row);
                            });
                        </script>
                    </div>
                    <div class="col-sm-12 col-md-4">
                        <div class="col-sm-9 col-md-10">
                            <div class="panel panel-default">
                                <div class="panel-body">
                                    <h5>
                                        <asp:Literal runat="server" Text="<%$ Resources:GlobalResource, Dashboard_LineChart%>"></asp:Literal></h5>

                                    <p>
                                        <asp:Literal runat="server" Text="<%$ Resources:GlobalResource,Dashboard_DownPaymentFromCustomer_ChartHeader %>"></asp:Literal>
                                    </p>
                                    <div id="downPaymentFromCustomerLinechart" style="width: 100%; height: 400px">
                                    </div>
                                </div>
                                <style>
                                    .morris-hover {
                                        position: absolute;
                                        z-index: auto;
                                        background-color: #fff;
                                        opacity: 0.4;
                                    }
                                </style>
                                <script type="text/javascript">
                                    Morris.Line({
                                        element: 'downPaymentFromCustomerLinechart',
                                        hideHover: 'auto',
                                        hideHover: 'auto',
                    <%=linechart%>
                                        xkey: 'x',
                                        ykeys: ['y', 'z'],
                                        labels: ['Y', 'Z']
                                    }).on('click', function (i, row) {
                                        console.log(i, row);
                                    });
                                </script>
                            </div>

                        </div>
                        <div class="col-sm-12 col-md-2 card card-block d-table-cell align-middle btn-group">
                            <asp:LinkButton ID="lnldownPaymentFromCustomerDay" runat="server" Width="65px" CssClass="btn btn-success pull-left" OnClick="lnldownPaymentFromCustomerDay_Click">
<asp:Literal runat="server"  Text="<%$ Resources:GlobalResource, Dashboard_lnkbtnDay%>"></asp:Literal></asp:LinkButton>
                            <asp:LinkButton ID="lnldownPaymentFromCustomerWeek" runat="server" Width="65px" CssClass="btn btn-warning pull-left" OnClick="lnldownPaymentFromCustomerWeek_Click"><asp:Literal runat="server"  Text="<%$ Resources:GlobalResource, Dashboard_lnkbtnWeek%>"></asp:Literal></asp:LinkButton>
                            <asp:LinkButton ID="lnldownPaymentFromCustomerMonth" runat="server" Width="65px" CssClass="btn btn-danger pull-left" OnClick="lnldownPaymentFromCustomerMonth_Click"><asp:Literal runat="server"  Text="<%$ Resources:GlobalResource, Dashboard_lnkbtnMonth%>"></asp:Literal></asp:LinkButton>
                            <asp:LinkButton ID="lnldownPaymentFromCustomerQuarter" runat="server" Width="65px" CssClass="btn btn-info pull-left" OnClick="lnldownPaymentFromCustomerQuarter_Click"><asp:Literal runat="server"  Text="<%$ Resources:GlobalResource, Dashboard_lnkbtnQuarter%>"></asp:Literal></asp:LinkButton>
                            <asp:LinkButton ID="lnldownPaymentFromCustomerYear" runat="server" Width="65px" CssClass="btn btn-primary pull-left" OnClick="lnldownPaymentFromCustomerYear_Click"><asp:Literal runat="server"  Text="<%$ Resources:GlobalResource, Dashboard_lnkbtnYear%>"></asp:Literal></asp:LinkButton>
                        </div>
                    </div>
                </div>

                <!--Down Payment To Supplier-->
                <div id="dvdownPaymentToSupplier" runat="server">
                    <div class="col-sm-12 col-md-4">
                        <div class="panel panel-default">
                            <div class="panel-body">

                                <h5>
                                    <asp:Literal runat="server" Text="<%$ Resources:GlobalResource, Dashboard_Piechart%>"></asp:Literal></h5>

                                <p>
                                    <asp:Literal runat="server" Text="<%$ Resources:GlobalResource, Dashboard_DownPaymentToSupplier_ChartHeader %>"></asp:Literal>
                                </p>
                                <div id="PiechartdownPaymentToSupplier" style="width: 100%; height: 400px"></div>
                            </div>
                        </div>
                        <script>
                                        <%=piechart%>
                            var options = {
                                series: {
                                    pie: {
                                        show: true,
                                        label: {
                                            innerRadius: 0.5,
                                            show: true,
                                            formatter: function (label, series) {

                                                return '<div style="font-size:11px ;text-align:center; padding:2px; color:white;">' + label + '<br/>' + Math.round(series.percent) + '%</div>';
                                            },
                                            background: {
                                                opacity: 0.8,
                                                color: '#000'
                                            }
                                        }
                                    }
                                },
                                legend: {
                                    show: true
                                },
                                grid: {
                                    hoverable: true
                                }
                            };
                            $(document).ready(function () {
                                $.plot($("#PiechartdownPaymentToSupplier"), dataSet, options);
                            });
                        </script>
                    </div>

                    <div class="col-sm-12 col-md-4 mb5">
                        <div class="panel panel-default">
                            <div class="panel-body">

                                <h5>
                                    <asp:Literal runat="server" Text="<%$ Resources:GlobalResource, Dashboard_Stackedchart%>"></asp:Literal></h5>

                                <p>
                                    <asp:Literal runat="server" Text="<%$ Resources:GlobalResource, Dashboard_DownPaymentToSupplier_ChartHeader %>"></asp:Literal>
                                </p>
                                <div id="downPaymentToSupplierstackedChart" style="width: 100%; height: 400px"></div>
                            </div>
                        </div>
                        <!-- panel-body -->
                        <style>
                            .morris-hover {
                                position: absolute;
                                z-index: auto;
                                background-color: #fff;
                                opacity: 0.4;
                            }
                        </style>
                        <script>
                            Morris.Bar({
                                element: 'downPaymentToSupplierstackedChart',
                                hideHover: 'auto',
                                             <%=stackedchart%>
                                xkey: 'x',
                                ykeys: ['y', 'z'],
                                labels: ['Y', 'Z']
                            }).on('click', function (i, row) {
                                console.log(i, row);
                            });
                        </script>
                    </div>

                    <div class="col-sm-12 col-md-4">
                        <div class="col-sm-9 col-md-10">
                            <div class="panel panel-default">
                                <div class="panel-body">
                                    <h5>
                                        <asp:Literal runat="server" Text="<%$ Resources:GlobalResource, Dashboard_LineChart%>"></asp:Literal></h5>

                                    <p>
                                        <asp:Literal runat="server" Text="<%$ Resources:GlobalResource, Dashboard_DownPaymentToSupplier_ChartHeader %>"></asp:Literal>
                                    </p>
                                    <div id="downPaymentToSupplierLinechart" style="width: 100%; height: 400px">
                                    </div>
                                </div>
                                <style>
                                    .morris-hover {
                                        position: absolute;
                                        z-index: auto;
                                        background-color: #fff;
                                        opacity: 0.4;
                                    }
                                </style>
                                <script type="text/javascript">
                                    Morris.Line({
                                        element: 'downPaymentToSupplierLinechart',
                                        hideHover: 'auto',
                                        hideHover: 'auto',
                    <%=linechart%>
                                        xkey: 'x',
                                        ykeys: ['y', 'z'],
                                        labels: ['Y', 'Z']
                                    }).on('click', function (i, row) {
                                        console.log(i, row);
                                    });
                                </script>
                            </div>

                        </div>
                        <div class="col-sm-12 col-md-2 card card-block d-table-cell align-middle btn-group">
                            <asp:LinkButton ID="lnkdownPaymentToSupplierDay" runat="server" Width="65px" CssClass="btn btn-success" OnClick="lnkdownPaymentToSupplierDay_Click"><asp:Literal runat="server"  Text="<%$ Resources:GlobalResource, Dashboard_lnkbtnDay%>"></asp:Literal></asp:LinkButton>
                            <asp:LinkButton ID="lnkdownPaymentToSupplierWeek" runat="server" Width="65px" CssClass="btn btn-warning" OnClick="lnkdownPaymentToSupplierWeek_Click"><asp:Literal runat="server"  Text="<%$ Resources:GlobalResource, Dashboard_lnkbtnWeek%>"></asp:Literal></asp:LinkButton>
                            <asp:LinkButton ID="lnkdownPaymentToSupplierMonth" runat="server" Width="65px" CssClass="btn btn-danger" OnClick="lnkdownPaymentToSupplierMonth_Click"><asp:Literal runat="server"  Text="<%$ Resources:GlobalResource, Dashboard_lnkbtnMonth%>"></asp:Literal></asp:LinkButton>
                            <asp:LinkButton ID="lnkdownPaymentToSupplierQuarter" runat="server" Width="65px" CssClass="btn btn-info" OnClick="lnkdownPaymentToSupplierQuarter_Click"><asp:Literal runat="server"  Text="<%$ Resources:GlobalResource, Dashboard_lnkbtnQuarter%>"></asp:Literal></asp:LinkButton>
                            <asp:LinkButton ID="lnkdownPaymentToSupplierYear" runat="server" Width="65px" CssClass="btn btn-primary" OnClick="lnkdownPaymentToSupplierYear_Click"><asp:Literal runat="server"  Text="<%$ Resources:GlobalResource, Dashboard_lnkbtnYear%>"></asp:Literal></asp:LinkButton>
                        </div>
                    </div>

                </div>

                <!--Payment From Customer-->
                <div id="dvPaymentFromCustomer" runat="server">

                    <div class="col-sm-12 col-md-4">
                        <div class="col-sm-9 col-md-10">
                            <div class="panel panel-default">
                                <div class="panel-body">

                                    <h5>
                                        <asp:Literal runat="server" Text="<%$ Resources:GlobalResource, Dashboard_LineChart%>"></asp:Literal></h5>

                                    <p>
                                        <asp:Literal runat="server" Text="<%$ Resources:GlobalResource,Dashboard_PaymentFromCustomer_ChartHeader %>"></asp:Literal>
                                    </p>
                                    <div id="PaymentFromCustomerLinechart" class="body-chart">
                                    </div>
                                </div>
                                <style>
                                    .morris-hover {
                                        position: absolute;
                                        z-index: auto;
                                        background-color: #fff;
                                        opacity: 0.4;
                                    }
                                </style>
                                <script type="text/javascript">
                                    Morris.Line({
                                        element: 'PaymentFromCustomerLinechart',
                                        hideHover: 'auto',
                                        hideHover: 'auto',
                    <%=linechart%>
                                        xkey: 'x',
                                        ykeys: ['y', 'z'],
                                        labels: ['Y', 'Z']
                                    }).on('click', function (i, row) {
                                        console.log(i, row);
                                    });
                                </script>
                            </div>

                        </div>
                        <div class="col-sm-12 col-md-2 card card-block d-table-cell align-middle btn-group">
                               <asp:LinkButton ID="lnkPaymentFromCustomerDay" runat="server" Width="65px" CssClass="btn btn-success" OnClick="lnkdownPaymentToSupplierDay_Click"><asp:Literal runat="server"  Text="<%$ Resources:GlobalResource, Dashboard_lnkbtnDay%>"></asp:Literal></asp:LinkButton>
                                                     <asp:LinkButton ID="lnkPaymentFromCustomerWeek" runat="server" Width="70px" CssClass="btn btn-warning" OnClick="lnkPaymentFromCustomerWeek_Click"><asp:Literal runat="server"  Text="<%$ Resources:GlobalResource, Dashboard_lnkbtnWeek%>"></asp:Literal></asp:LinkButton>
                            <asp:LinkButton ID="lnkPaymentFromCustomerMonth" runat="server" Width="70px" CssClass="btn btn-danger" OnClick="lnkPaymentFromCustomerMonth_Click"><asp:Literal runat="server"  Text="<%$ Resources:GlobalResource, Dashboard_lnkbtnMonth%>"></asp:Literal></asp:LinkButton>
                            <asp:LinkButton ID="lnkPaymentFromCustomerQuarter" runat="server" Width="70px" CssClass="btn btn-info" OnClick="lnkPaymentFromCustomerQuarter_Click"><asp:Literal runat="server"  Text="<%$ Resources:GlobalResource, Dashboard_lnkbtnQuarter%>"></asp:Literal></asp:LinkButton>
                            <asp:LinkButton ID="lnkPaymentFromCustomerYear" runat="server" Width="70px" CssClass="btn btn-primary" OnClick="lnkPaymentFromCustomerYear_Click"><asp:Literal runat="server"  Text="<%$ Resources:GlobalResource, Dashboard_lnkbtnYear%>"></asp:Literal></asp:LinkButton>
                        </div>
                    </div>
                    <div class="col-sm-12 col-md-4">
                        <div class="panel panel-default">
                            <div class="panel-body">
                                <h5>
                                    <asp:Literal runat="server" Text="<%$ Resources:GlobalResource, Dashboard_Piechart%>"></asp:Literal></h5>

                                <p>
                                    <asp:Literal runat="server" Text="<%$ Resources:GlobalResource,Dashboard_PaymentFromCustomer_ChartHeader %>"></asp:Literal>
                                </p>
                                <div id="PiechartPaymentFromCustomer" style="width: 100%; height: 400px"></div>
                            </div>
                        </div>
                        <script>
                                        <%=piechart%>
                            var options = {
                                series: {
                                    pie: {
                                        show: true,
                                        label: {
                                            innerRadius: 0.5,
                                            show: true,
                                            formatter: function (label, series) {

                                                return '<div style="font-size:11px ;text-align:center; padding:2px; color:white;">' + label + '<br/>' + Math.round(series.percent) + '%</div>';
                                            },
                                            background: {
                                                opacity: 0.8,
                                                color: '#000'
                                            }
                                        }
                                    }
                                },
                                legend: {
                                    show: true
                                },
                                grid: {
                                    hoverable: true
                                }
                            };
                            $(document).ready(function () {
                                $.plot($("#PiechartPaymentFromCustomer"), dataSet, options);
                            });
                        </script>
                    </div>
                    <div class="col-sm-12 col-md-4">
                        <div class="col-sm-9 col-md-10">
                            <div class="panel panel-default">
                                <div class="panel-body">
                                    <h5>
                                        <asp:Literal runat="server" Text="<%$ Resources:GlobalResource, Dashboard_Stackedchart%>"></asp:Literal></h5>

                                    <p>
                                        <asp:Literal runat="server" Text="<%$ Resources:GlobalResource,Dashboard_PaymentFromCustomer_ChartHeader %>"></asp:Literal>
                                    </p>
                                    <div id="chartPaymentFromCustomer" class="body-chart">
                                    </div>
                                </div>
                                <style>
                                    .morris-hover {
                                        position: absolute;
                                        z-index: auto;
                                        background-color: #fff;
                                        opacity: 0.4;
                                    }
                                </style>
                                <script>
                                    Morris.Bar({
                                        element: 'chartPaymentFromCustomer',
                                        hideHover: 'auto',
                                         <%=stackedchart%>
                                        xkey: 'x',
                                        ykeys: ['y', 'z'],
                                        labels: ['Y', 'Z']
                                    }).on('click', function (i, row) {
                                        console.log(i, row);
                                    });
                                </script>
                            </div>

                        </div>

                    </div>

                </div>

                <!--PaymentToSupplierEmployee-->
                <div id="dvPaymentToSupplierEmployee" runat="server">
                    <div class="col-sm-12 col-md-4">
                        <div class="col-sm-9 col-md-10">
                            <div class="panel panel-default">
                                <div class="panel-body">
                                    <h5>
                                        <asp:Literal runat="server" Text="<%$ Resources:GlobalResource, Dashboard_LineChart%>"></asp:Literal></h5>

                                    <p>
                                        <asp:Literal runat="server" Text="<%$ Resources:GlobalResource,Dashboard_PaymentToSupplierEmployee_ChartHeader %>"></asp:Literal>
                                    </p>
                                    <div id="Linechart" class="body-chart">
                                    </div>
                                </div>
                                <style>
                                    .morris-hover {
                                        position: absolute;
                                        z-index: auto;
                                        background-color: #fff;
                                        opacity: 0.4;
                                    }
                                </style>
                                <script type="text/javascript">
                                    Morris.Line({
                                        element: 'Linechart',
                                        hideHover: 'auto',
                                        hideHover: 'auto',
                    <%=linechart%>
                                        xkey: 'x',
                                        ykeys: ['y', 'z'],
                                        labels: ['Y', 'Z']
                                    }).on('click', function (i, row) {
                                        console.log(i, row);
                                    });
                                </script>
                            </div>

                        </div>
                        <div class="col-sm-12 col-md-2 card card-block d-table-cell align-middle btn-group">
                            <asp:LinkButton ID="lnkDay" runat="server" Width="70px" CssClass="btn btn-success" OnClick="lnkDay_Click"><asp:Literal runat="server"  Text="<%$ Resources:GlobalResource, Dashboard_lnkbtnDay%>"></asp:Literal></asp:LinkButton>
                            <asp:LinkButton ID="lnkBtnWeek" runat="server" Width="70px" CssClass="btn btn-warning" OnClick="lnkBtnWeek_Click"><asp:Literal runat="server"  Text="<%$ Resources:GlobalResource, Dashboard_lnkbtnWeek%>"></asp:Literal></asp:LinkButton>
                            <asp:LinkButton ID="lnkMonth" runat="server" Width="70px" CssClass="btn btn-danger" OnClick="lnkMonth_Click"><asp:Literal runat="server"  Text="<%$ Resources:GlobalResource, Dashboard_lnkbtnMonth%>"></asp:Literal></asp:LinkButton>
                              <asp:LinkButton ID="lnkQuarter" runat="server" Width="70px" CssClass="btn btn-info" OnClick="lnkQuarter_Click"><asp:Literal runat="server"  Text="<%$ Resources:GlobalResource, Dashboard_lnkbtnQuarter%>"></asp:Literal></asp:LinkButton>
                            <asp:LinkButton ID="lnkYear" runat="server" Width="70px" CssClass="btn btn-primary" OnClick="lnkYear_Click"><asp:Literal runat="server"  Text="<%$ Resources:GlobalResource, Dashboard_lnkbtnYear%>"></asp:Literal></asp:LinkButton>
                          
                        </div>
                    </div>

                    <div class="col-sm-12 col-md-4">
                        <div class="panel panel-default">
                            <div class="panel-body">

                                <h5>
                                    <asp:Literal runat="server" Text="<%$ Resources:GlobalResource, Dashboard_Piechart	%>"></asp:Literal></h5>

                                <p>
                                    <asp:Literal runat="server" Text="<%$ Resources:GlobalResource,Dashboard_PaymentToSupplierEmployee_ChartHeader %>"></asp:Literal>
                                </p>
                                <div id="PiechartPaymentToSupplierEmployee" style="width: 100%; height: 400px"></div>
                            </div>
                        </div>
                        <script>
                                        <%=piechart%>
                            var options = {
                                series: {
                                    pie: {
                                        show: true,
                                        label: {
                                            innerRadius: 0.5,
                                            show: true,
                                            formatter: function (label, series) {

                                                return '<div style="font-size:11px ;text-align:center; padding:2px; color:white;">' + label + '<br/>' + Math.round(series.percent) + '%</div>';
                                            },
                                            background: {
                                                opacity: 0.8,
                                                color: '#000'
                                            }
                                        }
                                    }
                                },
                                legend: {
                                    show: true
                                },
                                grid: {
                                    hoverable: true
                                }
                            };
                            $(document).ready(function () {
                                $.plot($("#PiechartPaymentToSupplierEmployee"), dataSet, options);
                            });
                        </script>
                    </div>

                    <div class="col-sm-12 col-md-4">
                        <div class="col-sm-9 col-md-10">
                            <div class="panel panel-default">
                                <div class="panel-body">


                                    <h5>
                                        <asp:Literal runat="server" Text="<%$ Resources:GlobalResource, Dashboard_Stackedchart%>"></asp:Literal></h5>

                                    <p>
                                        <asp:Literal runat="server" Text="<%$ Resources:GlobalResource,Dashboard_PaymentToSupplierEmployee_ChartHeader %>"></asp:Literal>
                                    </p>
                                    <div id="chartPaymentToSupplierEmployee" class="body-chart">
                                    </div>
                                </div>
                                <style>
                                    .morris-hover {
                                        position: absolute;
                                        z-index: auto;
                                        background-color: #fff;
                                        opacity: 0.4;
                                    }
                                </style>
                                <script>
                                    Morris.Bar({
                                        element: 'chartPaymentToSupplierEmployee',
                                        hideHover: 'auto',
                                         <%=stackedchart%>
                                        xkey: 'x',
                                        ykeys: ['y', 'z'],
                                        labels: ['Y', 'Z']
                                    }).on('click', function (i, row) {
                                        console.log(i, row);
                                    });
                                </script>
                            </div>

                        </div>

                    </div>
                </div>

                <!--CustomerInvoiceProcess-->
                <div id="dvCustomerInvoiceProcess" runat="server">

                    <div class="col-sm-12 col-md-4">
                        <div class="col-sm-9 col-md-10">
                            <div class="panel panel-default">
                                <div class="panel-body">



                                    <h5>
                                        <asp:Literal runat="server" Text="<%$ Resources:GlobalResource, Dashboard_LineChart%>"></asp:Literal></h5>

                                    <p>
                                        <asp:Literal runat="server" Text="<%$ Resources:GlobalResource,Dashboard_CustomerInvoiceProcess_ChartHeader %>"></asp:Literal>
                                    </p>
                                    <div id="CustomerInvoiceProcessLinechart" class="body-chart">
                                    </div>
                                </div>
                                <style>
                                    .morris-hover {
                                        position: absolute;
                                        z-index: auto;
                                        background-color: #fff;
                                        opacity: 0.4;
                                    }
                                </style>
                                <script type="text/javascript">
                                    Morris.Line({
                                        element: 'CustomerInvoiceProcessLinechart',
                                        hideHover: 'auto',
                                        hideHover: 'auto',
                    <%=linechart%>
                                        xkey: 'x',
                                        ykeys: ['y', 'z'],
                                        labels: ['Y', 'Z']
                                    }).on('click', function (i, row) {
                                        console.log(i, row);
                                    });
                                </script>
                            </div>

                        </div>
                        <div class="col-sm-12 col-md-2 card card-block d-table-cell align-middle btn-group">
                            <asp:LinkButton ID="lnkDayCustomerInvoiceProcess" runat="server" Width="70px" CssClass="btn btn-success" OnClick="lnkDayCustomerInvoiceProcess_Click"><asp:Literal runat="server"  Text="<%$ Resources:GlobalResource, Dashboard_lnkbtnDay%>"></asp:Literal></asp:LinkButton>
                            <asp:LinkButton ID="lnkWeekCustomerInvoiceProcess" runat="server" Width="70px" CssClass="btn btn-warning" OnClick="lnkWeekCustomerInvoiceProcess_Click"><asp:Literal runat="server"  Text="<%$ Resources:GlobalResource, Dashboard_lnkbtnWeek%>"></asp:Literal></asp:LinkButton>
                            <asp:LinkButton ID="lnkMonthCustomerInvoiceProcess" runat="server" Width="70px" CssClass="btn btn-danger" OnClick="lnkMonthCustomerInvoiceProcess_Click"><asp:Literal runat="server"  Text="<%$ Resources:GlobalResource, Dashboard_lnkbtnMonth%>"></asp:Literal></asp:LinkButton>
                              <asp:LinkButton ID="lnkQuarterCustomerInvoiceProcess" runat="server" Width="70px" CssClass="btn btn-info" OnClick="lnkQuarterCustomerInvoiceProcess_Click"><asp:Literal runat="server"  Text="<%$ Resources:GlobalResource, Dashboard_lnkbtnQuarter%>"></asp:Literal></asp:LinkButton>
                            <asp:LinkButton ID="lnkYearCustomerInvoiceProcess" runat="server" Width="70px" CssClass="btn btn-primary" OnClick="lnkYearCustomerInvoiceProcess_Click"><asp:Literal runat="server"  Text="<%$ Resources:GlobalResource, Dashboard_lnkbtnYear%>"></asp:Literal></asp:LinkButton>
                          
                        </div>
                    </div>
                    <div class="col-sm-12 col-md-4">
                        <div class="panel panel-default">
                            <div class="panel-body">


                                <h5>
                                    <asp:Literal runat="server" Text="<%$ Resources:GlobalResource, Dashboard_Piechart%>"></asp:Literal></h5>

                                <p>
                                    <asp:Literal runat="server" Text="<%$ Resources:GlobalResource,Dashboard_CustomerInvoiceProcess_ChartHeader %>"></asp:Literal>
                                </p>
                                <div id="PiechartCustomerInvoiceProcess" style="width: 100%; height: 400px"></div>
                            </div>
                        </div>
                        <script>
                                        <%=piechart%>
                            var options = {
                                series: {
                                    pie: {
                                        show: true,
                                        label: {
                                            innerRadius: 0.5,
                                            show: true,
                                            formatter: function (label, series) {

                                                return '<div style="font-size:11px ;text-align:center; padding:2px; color:white;">' + label + '<br/>' + Math.round(series.percent) + '%</div>';
                                            },
                                            background: {
                                                opacity: 0.8,
                                                color: '#000'
                                            }
                                        }
                                    }
                                },
                                legend: {
                                    show: true
                                },
                                grid: {
                                    hoverable: true
                                }
                            };
                            $(document).ready(function () {
                                $.plot($("#PiechartCustomerInvoiceProcess"), dataSet, options);
                            });
                        </script>
                    </div>
                    <div class="col-sm-12 col-md-4">
                        <div class="col-sm-9 col-md-10">
                            <div class="panel panel-default">
                                <div class="panel-body">

                                    <h5>
                                        <asp:Literal runat="server" Text="<%$ Resources:GlobalResource, Dashboard_Stackedchart%>"></asp:Literal></h5>

                                    <p>
                                        <asp:Literal runat="server" Text="<%$ Resources:GlobalResource,Dashboard_CustomerInvoiceProcess_ChartHeader %>"></asp:Literal>
                                    </p>
                                    <div id="chartCustomerInvoiceProcess" class="body-chart">
                                    </div>
                                </div>
                                <style>
                                    .morris-hover {
                                        position: absolute;
                                        z-index: auto;
                                        background-color: #fff;
                                        opacity: 0.4;
                                    }
                                </style>
                                <script>
                                    Morris.Bar({
                                        element: 'chartCustomerInvoiceProcess',
                                        hideHover: 'auto',
                                         <%=stackedchart%>
                                        xkey: 'x',
                                        ykeys: ['y', 'z'],
                                        labels: ['Y', 'Z']
                                    }).on('click', function (i, row) {
                                        console.log(i, row);
                                    });
                                </script>
                            </div>

                        </div>

                    </div>

                </div>

                <!--SupplierEmployeeGeneralExpenses-->
                <div id="dvSupplierEmployeeGeneralExpenses" runat="server">
                    <div class="col-sm-12 col-md-4">
                        <div class="col-sm-9 col-md-10">
                            <div class="panel panel-default">
                                <div class="panel-body">
                                                                      <h5>
                                        <asp:Literal runat="server" Text="<%$ Resources:GlobalResource, Dashboard_LineChart%>"></asp:Literal></h5>

                                    <p>
                                        <asp:Literal runat="server" Text="<%$ Resources:GlobalResource,Dashboard_SupplierEmployeeGeneralExpenses_ChartHeader %>"></asp:Literal>
                                    </p>
                                    <div id="SupplierEmployeeGeneralExpensesLinechart" style="width: 100%; height: 400px">
                                    </div>
                                </div>
                                <style>
                                    .morris-hover {
                                        position: absolute;
                                        z-index: auto;
                                        background-color: #fff;
                                        opacity: 0.4;
                                    }
                                </style>
                                <script type="text/javascript">
                                    Morris.Line({
                                        element: 'SupplierEmployeeGeneralExpensesLinechart',
                                        hideHover: 'auto',
                                        hideHover: 'auto',
                    <%=linechart%>
                                        xkey: 'x',
                                        ykeys: ['y', 'z'],
                                        labels: ['Y', 'Z']
                                    }).on('click', function (i, row) {
                                        console.log(i, row);
                                    });
                                </script>
                            </div>

                        </div>
                        <div class="col-sm-12 col-md-2 card card-block d-table-cell align-middle btn-group">
                            <asp:LinkButton ID="lnkSupplierEmployeeGeneralExpensesDay" runat="server" Width="70px" CssClass="btn btn-success" OnClick="lnkSupplierEmployeeGeneralExpensesDay_Click"><asp:Literal runat="server"  Text="<%$ Resources:GlobalResource, Dashboard_lnkbtnDay%>"></asp:Literal></asp:LinkButton>
                            <asp:LinkButton ID="lnkSupplierEmployeeGeneralExpensesWeek" runat="server" Width="70px" CssClass="btn btn-warning" OnClick="lnkSupplierEmployeeGeneralExpensesWeek_Click"><asp:Literal runat="server"  Text="<%$ Resources:GlobalResource, Dashboard_lnkbtnWeek%>"></asp:Literal></asp:LinkButton>
                            <asp:LinkButton ID="lnkSupplierEmployeeGeneralExpensesMonth" runat="server" Width="70px" CssClass="btn btn-danger" OnClick="lnkSupplierEmployeeGeneralExpensesMonth_Click"><asp:Literal runat="server"  Text="<%$ Resources:GlobalResource, Dashboard_lnkbtnMonth%>"></asp:Literal></asp:LinkButton>
                            <asp:LinkButton ID="lnkSupplierEmployeeGeneralExpensesYear" runat="server" Width="70px" CssClass="btn btn-primary" OnClick="lnkSupplierEmployeeGeneralExpensesYear_Click"><asp:Literal runat="server"  Text="<%$ Resources:GlobalResource, Dashboard_lnkbtnYear%>"></asp:Literal>
</asp:LinkButton>
                            <asp:LinkButton ID="lnkSupplierEmployeeGeneralExpensesQuarter" runat="server" Width="70px" CssClass="btn btn-info" OnClick="lnkSupplierEmployeeGeneralExpensesQuarter_Click"><asp:Literal runat="server"  Text="<%$ Resources:GlobalResource, Dashboard_lnkbtnQuarter%>"></asp:Literal></asp:LinkButton>
                        </div>
                    </div>
                    <div class="col-sm-12 col-md-4">
                        <div class="panel panel-default">
                            <div class="panel-body">



                                <h5>
                                    <asp:Literal runat="server" Text="<%$ Resources:GlobalResource, Dashboard_Piechart%>"></asp:Literal></h5>

                                <p>
                                    <asp:Literal runat="server" Text="<%$ Resources:GlobalResource,Dashboard_SupplierEmployeeGeneralExpenses_ChartHeader %>"></asp:Literal>
                                </p>
                                <div id="PiechartSupplierEmployeeGeneralExpenses" style="width: 100%; height: 400px"></div>
                            </div>
                        </div>
                        <script>
                                        <%=piechart%>
                            var options = {
                                series: {
                                    pie: {
                                        show: true,
                                        label: {
                                            innerRadius: 0.5,
                                            show: true,
                                            formatter: function (label, series) {

                                                return '<div style="font-size:11px ;text-align:center; padding:2px; color:white;">' + label + '<br/>' + Math.round(series.percent) + '%</div>';
                                            },
                                            background: {
                                                opacity: 0.8,
                                                color: '#000'
                                            }
                                        }
                                    }
                                },
                                legend: {
                                    show: true
                                },
                                grid: {
                                    hoverable: true
                                }
                            };
                            $(document).ready(function () {
                                $.plot($("#PiechartSupplierEmployeeGeneralExpenses"), dataSet, options);
                            });
                        </script>
                    </div>
                    <div class="col-sm-12 col-md-4">
                        <div class="col-sm-9 col-md-10">
                            <div class="panel panel-default">
                                <div class="panel-body">

                                    <h5>
                                        <asp:Literal runat="server" Text="<%$ Resources:GlobalResource, Dashboard_Stackedchart%>"></asp:Literal></h5>

                                    <p>
                                        <asp:Literal runat="server" Text="<%$ Resources:GlobalResource,Dashboard_SupplierEmployeeGeneralExpenses_ChartHeader %>"></asp:Literal>
                                    </p>
                                    <div id="chartSupplierEmployeeGeneralExpenses" style="width: 100%; height: 400px">
                                    </div>
                                </div>
                                <style>
                                    .morris-hover {
                                        position: absolute;
                                        z-index: auto;
                                        background-color: #fff;
                                        opacity: 0.4;
                                    }
                                </style>
                                <script>
                                    Morris.Bar({
                                        element: 'chartSupplierEmployeeGeneralExpenses',
                                        hideHover: 'auto',
                                         <%=stackedchart%>
                                        xkey: 'x',
                                        ykeys: ['y', 'z'],
                                        labels: ['Y', 'Z']
                                    }).on('click', function (i, row) {
                                        console.log(i, row);
                                    });
                                </script>
                            </div>
                        </div>
                    </div>
                </div>

                <!--NonPOBasedInvoice-->
                <div id="dvNonPOBasedInvoice" runat="server">
                    <div class="col-sm-12 col-md-4">
                        <div class="col-sm-9 col-md-10">
                            <div class="panel panel-default">
                                <div class="panel-body">
                                                                      <h5>
                                        <asp:Literal runat="server" Text="<%$ Resources:GlobalResource, Dashboard_LineChart%>"></asp:Literal></h5>

                                    <p>
                                        <asp:Literal runat="server" Text="<%$ Resources:GlobalResource,Dashboard_NonPOBasedInvoicer_ChartHeader %>"></asp:Literal>

                                    </p>
                                    <div id="NonPOBasedInvoiceLinechart" style="width: 100%; height: 400px">
                                    </div>
                                </div>
                                <style>
                                    .morris-hover {
                                        position: absolute;
                                        z-index: auto;
                                        background-color: #fff;
                                        opacity: 0.4;
                                    }
                                </style>
                                <script type="text/javascript">
                                    Morris.Line({
                                        element: 'NonPOBasedInvoiceLinechart',
                                        hideHover: 'auto',
                                        hideHover: 'auto',
                    <%=linechart%>
                                        xkey: 'x',
                                        ykeys: ['y', 'z'],
                                        labels: ['Y', 'Z']
                                    }).on('click', function (i, row) {
                                        console.log(i, row);
                                    });
                                </script>
                            </div>

                        </div>
                        <div class="col-sm-12 col-md-2 card card-block d-table-cell align-middle btn-group">
                            <asp:LinkButton ID="lnkNonPOBasedInvoiceDay" runat="server" Width="70px" CssClass="btn btn-success" OnClick="lnkNonPOBasedInvoiceDay_Click"><asp:Literal runat="server"  Text="<%$ Resources:GlobalResource, Dashboard_lnkbtnDay%>"></asp:Literal></asp:LinkButton>
                            <asp:LinkButton ID="lnkNonPOBasedInvoiceWeek" runat="server" Width="70px" CssClass="btn btn-warning" OnClick="lnkNonPOBasedInvoiceWeek_Click"><asp:Literal runat="server"  Text="<%$ Resources:GlobalResource, Dashboard_lnkbtnWeek%>"></asp:Literal></asp:LinkButton>
                            <asp:LinkButton ID="lnkNonPOBasedInvoiceMonth" runat="server" Width="70px" CssClass="btn btn-danger" OnClick="lnkNonPOBasedInvoiceMonth_Click"><asp:Literal runat="server"  Text="<%$ Resources:GlobalResource, Dashboard_lnkbtnMonth%>"></asp:Literal></asp:LinkButton>
                            <asp:LinkButton ID="lnkNonPOBasedInvoiceQuarter" runat="server" Width="70px" CssClass="btn btn-info" OnClick="lnkNonPOBasedInvoiceQuarter_Click"><asp:Literal runat="server"  Text="<%$ Resources:GlobalResource, Dashboard_lnkbtnQuarter%>"></asp:Literal></asp:LinkButton>
                            <asp:LinkButton ID="lnkNonPOBasedInvoiceYear" runat="server" Width="70px" CssClass="btn btn-primary" OnClick="lnkNonPOBasedInvoiceYear_Click"><asp:Literal runat="server"  Text="<%$ Resources:GlobalResource, Dashboard_lnkbtnYear%>"></asp:Literal></asp:LinkButton>

                        </div>
                    </div>
                    <div class="col-sm-12 col-md-4">
                        <div class="panel panel-default">
                            <div class="panel-body">

                                <h5>
                                    <asp:Literal runat="server" Text="<%$ Resources:GlobalResource, Dashboard_Piechart%>"></asp:Literal></h5>

                                <p>
                                    <asp:Literal runat="server" Text="<%$ Resources:GlobalResource,Dashboard_NonPOBasedInvoicer_ChartHeader %>"></asp:Literal>

                                </p>
                                <div id="PiechartNonPOBasedInvoice" style="width: 100%; height: 400px"></div>
                            </div>
                        </div>
                        <script>
                                        <%=piechart%>
                            var options = {
                                series: {
                                    pie: {
                                        show: true,
                                        label: {
                                            innerRadius: 0.5,
                                            show: true,
                                            formatter: function (label, series) {

                                                return '<div style="font-size:11px ;text-align:center; padding:2px; color:white;">' + label + '<br/>' + Math.round(series.percent) + '%</div>';
                                            },
                                            background: {
                                                opacity: 0.8,
                                                color: '#000'
                                            }
                                        }
                                    }
                                },
                                legend: {
                                    show: true
                                },
                                grid: {
                                    hoverable: true
                                }
                            };
                            $(document).ready(function () {
                                $.plot($("#PiechartNonPOBasedInvoice"), dataSet, options);
                            });
                        </script>
                    </div>
                    <div class="col-sm-12 col-md-4">
                        <div class="col-sm-9 col-md-10">
                            <div class="panel panel-default">
                                <div class="panel-body">

                                    <h5>
                                        <asp:Literal runat="server" Text="<%$ Resources:GlobalResource, Dashboard_Stackedchart%>"></asp:Literal></h5>

                                    <p>
                                        <asp:Literal runat="server" Text="<%$ Resources:GlobalResource,Dashboard_NonPOBasedInvoicer_ChartHeader %>"></asp:Literal>

                                    </p>
                                    <div id="chartNonPOBasedInvoice" style="width: 100%; height: 400px">
                                    </div>
                                </div>
                                <style>
                                    .morris-hover {
                                        position: absolute;
                                        z-index: auto;
                                        background-color: #fff;
                                        opacity: 0.4;
                                    }
                                </style>
                                <script>
                                    Morris.Bar({
                                        element: 'chartNonPOBasedInvoice',
                                        hideHover: 'auto',
                                         <%=stackedchart%>
                                        xkey: 'x',
                                        ykeys: ['y', 'z'],
                                        labels: ['Y', 'Z']
                                    }).on('click', function (i, row) {
                                        console.log(i, row);
                                    });
                                </script>
                            </div>
                        </div>
                    </div>
                </div>

                <!--PaymentToSupplier -->
                <div id="dvPaymentToSupplier" runat="server">
                    <div class="col-sm-12 col-md-4">
                        <div class="col-sm-9 col-md-10">
                            <div class="panel panel-default">
                                <div class="panel-body">
                                    <h5 class="subtitle mb5">Line Chart</h5>
                                    <p>Payment To Supplier</p>
                                    <div id="PaymentToSupplierLinechart" style="width: 100%; height: 400px">
                                    </div>
                                </div>
                                <style>
                                    .morris-hover {
                                        position: absolute;
                                        z-index: auto;
                                        background-color: #fff;
                                        opacity: 0.4;
                                    }
                                </style>
                                <script type="text/javascript">
                                    Morris.Line({
                                        element: 'PaymentToSupplierLinechart',
                                        hideHover: 'auto',
                                        hideHover: 'auto',
                    <%=linechart%>
                                        xkey: 'x',
                                        ykeys: ['y', 'z'],
                                        labels: ['Y', 'Z']
                                    }).on('click', function (i, row) {
                                        console.log(i, row);
                                    });
                                </script>
                            </div>

                        </div>
                        <div class="col-sm-12 col-md-2 card card-block d-table-cell align-middle btn-group">
                            <asp:LinkButton ID="lnkPaymentToSupplierDay" runat="server" Width="70px" CssClass="btn btn-success" OnClick="lnkPaymentToSupplierDay_Click"><asp:Literal runat="server"  Text="<%$ Resources:GlobalResource, Dashboard_lnkbtnDay%>"></asp:Literal></asp:LinkButton>
                            <asp:LinkButton ID="lnkPaymentToSupplierWeek" runat="server" Width="70px" CssClass="btn btn-warning" OnClick="lnkPaymentToSupplierWeek_Click"><asp:Literal runat="server"  Text="<%$ Resources:GlobalResource, Dashboard_lnkbtnWeek%>"></asp:Literal></asp:LinkButton>
                            <asp:LinkButton ID="lnkPaymentToSupplierMonth" runat="server" Width="70px" CssClass="btn btn-danger" OnClick="lnkPaymentToSupplierMonth_Click"><asp:Literal runat="server"  Text="<%$ Resources:GlobalResource, Dashboard_lnkbtnMonth%>"></asp:Literal></asp:LinkButton>
                            <asp:LinkButton ID="lnkPaymentToSupplierQuarter" runat="server" Width="70px" CssClass="btn btn-info" OnClick="lnkPaymentToSupplierQuarter_Click"><asp:Literal runat="server"  Text="<%$ Resources:GlobalResource, Dashboard_lnkbtnQuarter%>"></asp:Literal></asp:LinkButton>
                            <asp:LinkButton ID="lnkPaymentToSupplierYear" runat="server" Width="70px" CssClass="btn btn-primary" OnClick="lnkPaymentToSupplierYear_Click"><asp:Literal runat="server"  Text="<%$ Resources:GlobalResource, Dashboard_lnkbtnYear%>"></asp:Literal></asp:LinkButton>
                        </div>
                    </div>
                    <div class="col-sm-12 col-md-4">
                        <div class="panel panel-default">
                            <div class="panel-body">
                                <h5>
                                    <asp:Literal runat="server" Text="<%$ Resources:GlobalResource, Dashboard_Piechart	%>"></asp:Literal></h5>

                                <p>
                                    <asp:Literal runat="server" Text="<%$ Resources:GlobalResource, Dashboard_PaymentToSupplier_ChartHeader%>"></asp:Literal>

                                </p>
                                <div id="PieChartPaymentToSupplier" style="width: 100%; height: 400px"></div>
                            </div>
                        </div>
                        <script>
                                        <%=piechart%>
                            var options = {
                                series: {
                                    pie: {
                                        show: true,
                                        label: {
                                            innerRadius: 0.5,
                                            show: true,
                                            formatter: function (label, series) {

                                                return '<div style="font-size:11px ;text-align:center; padding:2px; color:white;">' + label + '<br/>' + Math.round(series.percent) + '%</div>';
                                            },
                                            background: {
                                                opacity: 0.8,
                                                color: '#000'
                                            }
                                        }
                                    }
                                },
                                legend: {
                                    show: true
                                },
                                grid: {
                                    hoverable: true
                                }
                            };
                            $(document).ready(function () {
                                $.plot($("#PieChartPaymentToSupplier"), dataSet, options);
                            });
                        </script>
                    </div>
                    <div class="col-sm-12 col-md-4">
                        <div class="col-sm-9 col-md-10">
                            <div class="panel panel-default">
                                <div class="panel-body">

                                    <h5>
                                        <asp:Literal runat="server" Text="<%$ Resources:GlobalResource, Dashboard_Stackedchart	%>"></asp:Literal></h5>

                                    <p>
                                        <asp:Literal runat="server" Text="<%$ Resources:GlobalResource, Dashboard_PaymentToSupplier_ChartHeader%>"></asp:Literal>

                                    </p>

                                    <div id="chartPaymentToSupplier" style="width: 100%; height: 400px">
                                    </div>
                                </div>
                                <style>
                                    .morris-hover {
                                        position: absolute;
                                        z-index: auto;
                                        background-color: #fff;
                                        opacity: 0.4;
                                    }
                                </style>
                                <script>
                                    Morris.Bar({
                                        element: 'chartPaymentToSupplier',
                                        hideHover: 'auto',
                                         <%=stackedchart%>
                                        xkey: 'x',
                                        ykeys: ['y', 'z'],
                                        labels: ['Y', 'Z']
                                    }).on('click', function (i, row) {
                                        console.log(i, row);
                                    });
                                </script>
                            </div>
                        </div>
                    </div>
                </div>

                <!-- EmployeeGeneralExpenses -->
                <div id="dvEmployeeGeneralExpenses" runat="server">
                    <div class="col-sm-12 col-md-4">
                        <div class="col-sm-9 col-md-10">
                            <div class="panel panel-default">
                                <div class="panel-body">
                                    <h5>
                                        <asp:Literal runat="server" Text="<%$ Resources:GlobalResource, Dashboard_LineChart%>"></asp:Literal></h5>

                                    <p>
                                        <asp:Literal runat="server" Text="<%$ Resources:GlobalResource,Dashboard_EmployeeGeneralExpenses_ChartHeader %>"></asp:Literal>

                                    </p>
                                    <div id="EmployeeGeneralExpensesLinechart" style="width: 100%; height: 400px">
                                    </div>
                                </div>
                                <style>
                                    .morris-hover {
                                        position: absolute;
                                        z-index: auto;
                                        background-color: #fff;
                                        opacity: 0.4;
                                    }
                                </style>
                                <script type="text/javascript">
                                    Morris.Line({
                                        element: 'EmployeeGeneralExpensesLinechart',
                                        hideHover: 'auto',
                                        hideHover: 'auto',
                    <%=linechart%>
                                        xkey: 'x',
                                        ykeys: ['y', 'z'],
                                        labels: ['Y', 'Z']
                                    }).on('click', function (i, row) {
                                        console.log(i, row);
                                    });
                                </script>
                            </div>

                        </div>
                        <div class="col-sm-12 col-md-2 card card-block d-table-cell align-middle btn-group">
                            <asp:LinkButton ID="lnkEmployeeGeneralExpensesDay" runat="server" Width="60px" CssClass="btn btn-success" OnClick="lnkEmployeeGeneralExpensesDay_Click"><asp:Literal runat="server"  Text="<%$ Resources:GlobalResource, Dashboard_lnkbtnDay%>"></asp:Literal></asp:LinkButton>
                            <asp:LinkButton ID="lnkEmployeeGeneralExpensesWeek" runat="server" Width="60px" CssClass="btn btn-warning" OnClick="lnkEmployeeGeneralExpensesWeek_Click"><asp:Literal runat="server"  Text="<%$ Resources:GlobalResource, Dashboard_lnkbtnWeek%>"></asp:Literal></asp:LinkButton>
                            <asp:LinkButton ID="lnkEmployeeGeneralExpensesMonth" runat="server" Width="60px" CssClass="btn btn-danger" OnClick="lnkEmployeeGeneralExpensesMonth_Click"><asp:Literal runat="server"  Text="<%$ Resources:GlobalResource, Dashboard_lnkbtnMonth%>"></asp:Literal></asp:LinkButton>
                            <asp:LinkButton ID="lnkEmployeeGeneralExpensesQuarter" runat="server" Width="60px" CssClass="btn btn-info" OnClick="lnkEmployeeGeneralExpensesQuarter_Click"><asp:Literal runat="server"  Text="<%$ Resources:GlobalResource, Dashboard_lnkbtnQuarter%>"></asp:Literal></asp:LinkButton>
                            <asp:LinkButton ID="lnkEmployeeGeneralExpensesYear" runat="server" Width="60px" CssClass="btn btn-primary" OnClick="lnkEmployeeGeneralExpensesYear_Click"><asp:Literal runat="server"  Text="<%$ Resources:GlobalResource, Dashboard_lnkbtnYear%>"></asp:Literal></asp:LinkButton>
                        </div>
                    </div>
                    <div class="col-sm-12 col-md-4">
                        <div class="panel panel-default">
                            <div class="panel-body">
                                <h5>
                                    <asp:Literal runat="server" Text="<%$ Resources:GlobalResource,Dashboard_Piechart%>"></asp:Literal></h5>

                                <p>
                                    <asp:Literal runat="server" Text="<%$ Resources:GlobalResource,Dashboard_EmployeeGeneralExpenses_ChartHeader %>"></asp:Literal>

                                </p>
                                <div id="PieChartEmployeeGeneralExpenses" style="width: 100%; height: 400px"></div>
                            </div>
                        </div>
                        <script>
                                        <%=piechart%>
                            var options = {
                                series: {
                                    pie: {
                                        show: true,
                                        label: {
                                            innerRadius: 0.5,
                                            show: true,
                                            formatter: function (label, series) {

                                                return '<div style="font-size:11px ;text-align:center; padding:2px; color:white;">' + label + '<br/>' + Math.round(series.percent) + '%</div>';
                                            },
                                            background: {
                                                opacity: 0.8,
                                                color: '#000'
                                            }
                                        }
                                    }
                                },
                                legend: {
                                    show: true
                                },
                                grid: {
                                    hoverable: true
                                }
                            };
                            $(document).ready(function () {
                                $.plot($("#PieChartEmployeeGeneralExpenses"), dataSet, options);
                            });
                        </script>
                    </div>
                    <div class="col-sm-12 col-md-4">
                        <div class="col-sm-9 col-md-10">
                            <div class="panel panel-default">
                                <div class="panel-body">
                                    <h5>
                                        <asp:Literal runat="server" Text="<%$ Resources:GlobalResource, Dashboard_Stackedchart%>"></asp:Literal></h5>
                                    <p>
                                        <asp:Literal runat="server" Text="<%$ Resources:GlobalResource,Dashboard_EmployeeGeneralExpenses_ChartHeader %>"></asp:Literal>
                                    </p>

                                    <div id="chartEmployeeGeneralExpenses" style="width: 100%; height: 400px">
                                    </div>
                                </div>
                                <style>
                                    .morris-hover {
                                        position: absolute;
                                        z-index: auto;
                                        background-color: #fff;
                                        opacity: 0.4;
                                    }
                                </style>
                                <script>
                                    Morris.Bar({
                                        element: 'chartEmployeeGeneralExpenses',
                                        hideHover: 'auto',
                                         <%=stackedchart%>
                                        xkey: 'x',
                                        ykeys: ['y', 'z'],
                                        labels: ['Y', 'Z']
                                    }).on('click', function (i, row) {
                                        console.log(i, row);
                                    });
                                </script>
                            </div>
                        </div>
                    </div>
                </div>

                <!--PaymentToEmployee -->
                <div id="dvPaymentToEmployee" runat="server">
                    <div class="col-sm-12 col-md-4">
                        <div class="col-sm-9 col-md-10">
                            <div class="panel panel-default">
                                <div class="panel-body">
                                    <h5>
                                        <asp:Literal runat="server" Text="<%$ Resources:GlobalResource, Dashboard_LineChart%>"></asp:Literal></h5>

                                    <p>
                                        <asp:Literal runat="server" Text="<%$ Resources:GlobalResource,Dashboard_PaymentToEmployee_ChartHeader %>"></asp:Literal>

                                    </p>
                                    <div id="PaymentToEmployeeLinechart" style="width: 100%; height: 400px">
                                    </div>
                                </div>
                                <style>
                                    .morris-hover {
                                        position: absolute;
                                        z-index: auto;
                                        background-color: #fff;
                                        opacity: 0.4;
                                    }
                                </style>
                                <script type="text/javascript">
                                    Morris.Line({
                                        element: 'PaymentToEmployeeLinechart',
                                        hideHover: 'auto',
                                        hideHover: 'auto',
                    <%=linechart%>
                                        xkey: 'x',
                                        ykeys: ['y', 'z'],
                                        labels: ['Y', 'Z']
                                    }).on('click', function (i, row) {
                                        console.log(i, row);
                                    });
                                </script>
                            </div>

                        </div>
                        <div class="col-sm-12 col-md-2 card card-block d-table-cell align-middle btn-group">
                            <asp:LinkButton ID="lnkPaymentToEmployeeDay" runat="server" Width="60px" CssClass="btn btn-success" OnClick="lnkPaymentToEmployeeDay_Click"><asp:Literal runat="server"  Text="<%$ Resources:GlobalResource, Dashboard_lnkbtnDay%>"></asp:Literal></asp:LinkButton>
                            <asp:LinkButton ID="lnkPaymentToEmployeeWeek" runat="server" Width="60px" CssClass="btn btn-warning" OnClick="lnkPaymentToEmployeeWeek_Click"><asp:Literal runat="server"  Text="<%$ Resources:GlobalResource, Dashboard_lnkbtnWeek%>"></asp:Literal></asp:LinkButton>
                            <asp:LinkButton ID="lnkPaymentToEmployeeMonth" runat="server" Width="60px" CssClass="btn btn-danger" OnClick="lnkPaymentToEmployeeMonth_Click"><asp:Literal runat="server"  Text="<%$ Resources:GlobalResource, Dashboard_lnkbtnMonth%>"></asp:Literal></asp:LinkButton>
                            <asp:LinkButton ID="lnkPaymentToEmployeeQuarter" runat="server" Width="60px" CssClass="btn btn-info" OnClick="lnkPaymentToEmployeeQuarter_Click"><asp:Literal runat="server"  Text="<%$ Resources:GlobalResource, Dashboard_lnkbtnQuarter%>"></asp:Literal></asp:LinkButton>
                            <asp:LinkButton ID="lnkPaymentToEmployeeYear" runat="server" Width="60px" CssClass="btn btn-primary" OnClick="lnkPaymentToEmployeeYear_Click"><asp:Literal runat="server"  Text="<%$ Resources:GlobalResource, Dashboard_lnkbtnYear%>"></asp:Literal></asp:LinkButton>
                        </div>
                    </div>
                    <div class="col-sm-12 col-md-4">
                        <div class="panel panel-default">
                            <div class="panel-body">
                                <%-- <h5 class="subtitle mb5">Pie Chart</h5>
                                <p class="mb15">Payment To Employee</p>--%>
                                <h5>
                                    <asp:Literal runat="server" Text="<%$ Resources:GlobalResource, Dashboard_Piechart%>"></asp:Literal></h5>

                                <p>
                                    <asp:Literal runat="server" Text="<%$ Resources:GlobalResource,Dashboard_PaymentToEmployee_ChartHeader %>"></asp:Literal>

                                </p>
                                <div id="PieChartPaymentToEmployee" style="width: 100%; height: 400px"></div>
                            </div>
                        </div>
                        <script>
                                        <%=piechart%>
                            var options = {
                                series: {
                                    pie: {
                                        show: true,
                                        label: {
                                            innerRadius: 0.5,
                                            show: true,
                                            formatter: function (label, series) {

                                                return '<div style="font-size:11px ;text-align:center; padding:2px; color:white;">' + label + '<br/>' + Math.round(series.percent) + '%</div>';
                                            },
                                            background: {
                                                opacity: 0.8,
                                                color: '#000'
                                            }
                                        }
                                    }
                                },
                                legend: {
                                    show: true
                                },
                                grid: {
                                    hoverable: true
                                }
                            };
                            $(document).ready(function () {
                                $.plot($("#PieChartPaymentToEmployee"), dataSet, options);
                            });
                        </script>
                    </div>
                    <div class="col-sm-12 col-md-4">
                        <div class="col-sm-9 col-md-10">
                            <div class="panel panel-default">
                                <div class="panel-body">
                                    <h5>
                                        <asp:Literal runat="server" Text="<%$ Resources:GlobalResource, Dashboard_Stackedchart%>"></asp:Literal></h5>

                                    <p>
                                        <asp:Literal runat="server" Text="<%$ Resources:GlobalResource,Dashboard_PaymentToEmployee_ChartHeader %>"></asp:Literal>

                                    </p>
                                    <div id="chartPaymentToEmployee" style="width: 100%; height: 400px">
                                    </div>
                                </div>
                                <style>
                                    .morris-hover {
                                        position: absolute;
                                        z-index: auto;
                                        background-color: #fff;
                                        opacity: 0.4;
                                    }
                                </style>
                                <script>
                                    Morris.Bar({
                                        element: 'chartPaymentToEmployee',
                                        hideHover: 'auto',
                                         <%=stackedchart%>
                                        xkey: 'x',
                                        ykeys: ['y', 'z'],
                                        labels: ['Y', 'Z']
                                    }).on('click', function (i, row) {
                                        console.log(i, row);
                                    });
                                </script>
                            </div>
                        </div>
                    </div>
                </div>

            </div>
        </div>
    </div>

</asp:Content>

