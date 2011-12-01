<%@ Page Language="C#" Inherits="System.Web.Mvc.ViewPage<object>" %>
<input type="button" onclick="PopulateMathString('<%= Model.ToString() %>')" value="<%= Model.ToString() %>" />
