$(function ()
{
    var key = getUrlParam('q');
    var page = getUrlParam('page');
    var match;

    if (page == "null")
    {
        page = "1";
    }
    //��¼
    $.ajax({
        type: "get",
        async: false,  // ����ͬ����ʽ  ********
        url: "/Check/Search.aspx?KeyName=" + escape(key) + "&page=" + page,
        datatype: "json",
        success: function (msg)
        {
            match = msg;
        }
    });
    $("#Search_Content").html(match);
})
//���ղ���
function getUrlParam(name)
{
    var reg = new RegExp("(^|&)" + name + "=([^&]*)(&|$)"); //����һ������Ŀ�������������ʽ����
    var r = window.location.search.substr(1).match(reg);  //ƥ��Ŀ�����
    if (r != null) return unescape(r[2]); return null; //���ز���ֵ
}
