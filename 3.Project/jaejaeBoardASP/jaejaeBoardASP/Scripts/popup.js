function Popup() {
    this.getDocHeight = function () {
        return Math.max(
            Math.max(document.body.scrollHeight, document.documentElement.scrollHeight),
            Math.max(document.body.offsetHeight, document.documentElement.offsetHeight),
            Math.max(document.body.clientHeight, document.documentElement.clientHeight)
        );
    }

    this.winPopupLayerBackground = document.getElementById('winPopupLayerBackground');
    this.winPopupLayer = document.getElementById('winPopupLayer');

    this.winLoadingBackground = document.getElementById('winLoadingBackground');
    this.winLoadingLayer = document.getElementById('winLoadingLayer');

    this.loadingHtml = "<div style='background-color:#ffffff;position: absolute;top: 50%;left: 50%;width: 200px;height: 50px;z-index:101;margin-left:-110px;margin-top:-35px;text-align: center;padding:10px;font-weight:bold;font-size:15px;border:2px solid #004EA1;box-sizing:content-box;color:#004EA1;border-radius:5px;'>처리중입니다.<br />잠시만 기다려 주세요.<marquee direction='right' width='100px' style='font-size:45px;margin-top:-10px;'> - - - </marquee></div>";

    this.Open = function (sURL, nWidth, nHeight) {
        this.winPopupLayerBackground.style.left = '0px'
        this.winPopupLayerBackground.style.top = '0px'
        this.winPopupLayerBackground.style.width = '100%'

        this.winPopupLayerBackground.style.background = "#000";
        this.winPopupLayerBackground.style.opacity = (50 / 100);
        this.winPopupLayerBackground.style.filter = 'alpha(opacity=50)';

        this.winPopupLayerBackground.style.height = this.getDocHeight() + 'px';
        this.winPopupLayerBackground.style.display = '';

        this.winPopupLayer.style.left = "50%";
        this.winPopupLayer.style.top = "50%";
        this.winPopupLayer.style.marginLeft = nWidth / 2 * -1 + "px";
        this.winPopupLayer.style.marginTop = nHeight / 2 * -1 + document.body.scrollTop + "px";
        this.winPopupLayer.style.width = nWidth + "px";
        this.winPopupLayer.style.height = nHeight + "px";

        this.winPopupLayer.innerHTML = this.loadingHtml;
        this.winPopupLayer.style.display = '';
        $(this.winPopupLayer).draggable({ handle: 'h1' });
        this.load(sURL);
    }

    this.Close = function () {
        this.winPopupLayerBackground.style.display = 'none';
        this.winPopupLayer.style.display = 'none';
        this.winLoadingBackground.style.display = 'none';
        this.winLoadingLayer.style.display = 'none';
    }

    this.load = function (sURL) {
        $("#winPopupLayer").load(sURL);
    }

    this.OpenLoading = function () {
        this.winLoadingBackground.style.left = '0px'
        this.winLoadingBackground.style.top = '0px'
        this.winLoadingBackground.style.width = '100%'

        //this.winLoadingBackground.style.background = "#fff";
        this.winLoadingBackground.style.opacity = (50 / 100);
        this.winLoadingBackground.style.filter = 'alpha(opacity=50)';

        this.winLoadingBackground.style.height = this.getDocHeight() + 'px';
        this.winLoadingBackground.style.display = '';

        var nWidth = 200;
        var nHeight = 100;

        this.winLoadingLayer.style.left = "50%";
        this.winLoadingLayer.style.top = "50%";
        this.winLoadingLayer.style.marginLeft = nWidth / 2 * -1 + "px";
        this.winLoadingLayer.style.marginTop = nHeight / 2 * -1 + document.body.scrollTop + "px";
        this.winLoadingLayer.style.width = nWidth + "px";
        this.winLoadingLayer.style.height = nHeight + "px";

        this.winLoadingLayer.innerHTML = this.loadingHtml;
        this.winLoadingLayer.style.display = '';
    }

    this.CloseLoading = function () {
        this.winLoadingBackground.style.display = 'none';
        this.winLoadingLayer.style.display = 'none';
    }
}