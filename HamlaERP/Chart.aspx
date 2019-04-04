<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Chart.aspx.cs" Inherits="Chart" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script src="../../../infra_ui/js/1.8.3.jquery.min.js"></script>
    <script src="../../../infra_ui/js/flot/jquery.flot.min.js"></script>
    <script src="../../../infra_ui/js/flot/jquery.flot.pie.min.js"></script>
    <script src="../../../infra_ui/js/raphael-2.1.0.min.js"></script>
    <script src="../../../infra_ui/js/morris.min.js"></script>
    
</head>
<body>
    <form id="form1" runat="server">
        <script>
            //******* PIE CHART
            var dataSet = [
                { label: "Asia", data: 4119630000, color: "#005CDE" },
                { label: "Latin America", data: 590950000, color: "#00A36A" },
                { label: "Africa", data: 1012960000, color: "#7D0096" },
                { label: "Oceania", data: 35100000, color: "#992B00" },
                { label: "Europe", data: 727080000, color: "#DE000F" },
                { label: "North America", data: 344120000, color: "#ED7B00" }
            ];

            var options = {
                series: {
                    pie: {
                        show: true,
                        label: {
                            show: true,
                            radius: 140,
                            formatter: function (label, series) {
                                return '<div style="border:1px solid grey;font-size:8pt;text-align:center;padding:5px;color:white;">' +
                                label + ' : ' +
                                Math.round(series.percent) +
                                '%</div>';
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
                $.plot($("#flot-placeholder"), dataSet, options);
            });
</script>
    <div id="flot-placeholder" style="width: 100%; height: 350px"></div>
    <div id="graph"></div>
    <script>
        Morris.Donut({
            element: 'graph',
            data: [
              { value: 60, label: 'foo' },
              { value: 40, label: 'bar' }
              
            ],
            formatter: function (x) { return x + "%" }
        }).on('click', function (i, row) {
            console.log(i, row);
        });
    </script>
    </form>
</body>
</html>
