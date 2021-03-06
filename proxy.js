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
    req.setHeader("Accept-Encoding", "identity");
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
    * {
        -moz-user-select: none;
    }
    #SITE_BACKGROUND, #SITE_ROOT {
        top: 0 !important;
    }
</style>
                `);
                this.queue(null);
            })).pipe(node.createWriteStream());
        }
    }
], true));
app.use((req, res) => proxy.web(req, res));
http.createServer(app).listen(3000);
