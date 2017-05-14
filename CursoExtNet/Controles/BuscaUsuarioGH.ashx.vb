Imports System.Web
Imports System.Web.Services

Public Class BuscaUsuarioGH
    Implements System.Web.IHttpHandler

    Sub ProcessRequest(ByVal _context As HttpContext) Implements IHttpHandler.ProcessRequest
        _context.Response.ContentType = "text/json"
        Dim _query As String = String.Empty
        Dim _start As Int32 = 0
        Dim _limit As Int32 = 15

        If _context.Request("start") IsNot Nothing Then _start = _context.Request("start")

        If _context.Request("query") IsNot Nothing Then _query = _context.Request("query")

        If _query.Length > 0 Then
            Dim _pl As List(Of clsUsuario) = clsUsuario.BuscarParaActividad(_query)
            Dim _provs As Ext.Net.Paging(Of clsUsuario) = New Ext.Net.Paging(Of clsUsuario)(_pl, _pl.Count)
            _context.Response.Write(String.Format("{{'Articulo':{0}}}", Ext.Net.JSON.Serialize(_provs.Data)))
        End If

    End Sub

    ReadOnly Property IsReusable() As Boolean Implements IHttpHandler.IsReusable
        Get
            Return False
        End Get
    End Property

End Class