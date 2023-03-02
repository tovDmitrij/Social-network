const { createProxyMiddleware } = require('http-proxy-middleware');

const context = [
    //"/weatherforecast",
    //"/account",
];

module.exports = function (app) {
    const appProxy = createProxyMiddleware(context, {
        target: 'https://localhost:7254',
        secure: false
    });

    app.use(appProxy);
};