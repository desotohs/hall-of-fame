const connect = require("connect");
const harmon = require("harmon");
const http = require("http");
const httpProxy = require("http-proxy");
const through = require("through");

let app = connect();
let proxy = httpProxy.createProxyServer({
    "target": "https://username.wixsite.com/",
    "secure": false
});
proxy.on("proxyReq", req => {
    req.setHeader("Host", "kpirankings.wixsite.com");
});
app.use(harmon([], [
    {
        "query": "head",
        "func": node => {
            node.createReadStream().pipe(through(null, function() {
                this.queue(`
<style type="text/css">
    #WIX_ADS {
        display: none;
    }
</style>
<script type="text/javascript">
    setInterval(function() {
        var iframes = document.querySelectorAll("iframe#i0xshmtviframe");
        for (var i = 0; i < iframes.length; ++i) {
            if (iframes[i].getAttribute("data-realHeight") != iframes[i].clientHeight) {
                var h = iframes[i].clientHeight + 40;
                iframes[i].style.height = "" + h + "px";
                iframes[i].setAttribute("data-realHeight", h);
            }
        }
    }, 1000);
</script>
                `);
                this.queue(null);
            })).pipe(node.createWriteStream());
        }
    }
], true));
app.use((req, res) => proxy.web(req, res));
http.createServer(app).listen(3000);
