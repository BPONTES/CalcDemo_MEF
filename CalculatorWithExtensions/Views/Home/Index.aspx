<%@ Page Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<CalculatorInterfaces.ICalculator>" %>
<%@ Import Namespace="CalculatorInterfaces" %>
<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Home Page
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
<script language="javascript" type="text/javascript">
    PopulateMathString = function (aString) {
        mathbox = document.getElementsByName('mathstring')[0]
        mathbox.value = mathbox.value + aString
    }

    Clear = function () {
        mathbox = document.getElementsByName('mathstring')[0]
        mathbox.value = "";
    }
</script>
    <form action="Home" method="post">
        <input type="text" name="mathstring" id="mathstring" value="<%=ViewData["Result"] %>" readonly="readonly"/>
        <table>
        <tr><td><% Html.RenderPartial("number", 1);%></td><td><% Html.RenderPartial("number", 2);%></td><td><% Html.RenderPartial("number", 3);%></td></tr>
        <tr><td><% Html.RenderPartial("number", 4);%></td><td><% Html.RenderPartial("number", 5);%></td><td><% Html.RenderPartial("number", 6);%></td></tr>
        <tr><td><% Html.RenderPartial("number", 7);%></td><td><% Html.RenderPartial("number", 8);%></td><td><% Html.RenderPartial("number", 9);%></td></tr>
        <tr><td><% Html.RenderPartial("number", 0);%></td><td><input type="button" onclick="Clear()" value="C" /> </td><td><input id="equalButton" type="submit" value="=" /></td></tr>
        </table>

        <table>
        <tr>
        <% foreach (char i in Model.GetSupportedOperations())
           {%>
            <td><%
               Html.RenderPartial("number", i);%></td>
           <%
           }%>
           </tr>
           </table>
    </form>
</asp:Content>
