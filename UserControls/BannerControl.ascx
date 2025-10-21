<%@ Control Language="C#" AutoEventWireup="true" CodeFile="BannerControl.ascx.cs"
    Inherits="BannerControl" %>

<div class="carousel-wrapper swiper-style relative overflow-x-hidden">
    <div class="swiper-wrapper">
        <% for (int i = 0; i < intPicListRowCount; i++)
           {
               string Url = dstPicList.Tables[0].Rows[i]["Url"].ToString();
               string Beizhu = dstPicList.Tables[0].Rows[i]["Beizhu"].ToString();
               string Path = dstPicList.Tables[0].Rows[i]["Path"].ToString();
        %>
        <div class="swiper-slide">
            <div alt="<%=Beizhu %>" class="swiper-lazy bg-cover bg-center bg-black flex items-center justify-center">
            	<img src="<%=Path %>" style="width:100%;" />
            </div>
        </div>
        <%} %>
    </div>
    <div class="swiper-pagination"></div>
    <div class="swiper-button-prev"><span class="fas fa-angle-left"></span></div>
    <div class="swiper-button-next"><span class="fas fa-angle-right"></span></div>
</div>
