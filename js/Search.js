$(function ()
{
    var key = getUrlParam('q');
    var page = getUrlParam('page');
    var match;

    if (page == "null")
    {
        page = "1";
    }
    //登录
    $.ajax({
        type: "get",
        async: false,  // 设置同步方式  ********
        url: "/Check/Search.aspx?KeyName=" + escape(key) + "&page=" + page,
        datatype: "json",
        success: function (msg)
        {
            match = msg;
        }
    });
    $("#Search_Content").html(match);
})
//接收参数
function getUrlParam(name)
{
    var reg = new RegExp("(^|&)" + name + "=([^&]*)(&|$)"); //构造一个含有目标参数的正则表达式对象
    var r = window.location.search.substr(1).match(reg);  //匹配目标参数
    if (r != null) return unescape(r[2]); return null; //返回参数值
}
