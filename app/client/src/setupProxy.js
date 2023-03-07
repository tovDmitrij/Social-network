const { createProxyMiddleware } = require('http-proxy-middleware');


export const API_URL = 'https://localhost:7254'


module.exports = function (app) {
    const appProxy = createProxyMiddleware({
        target: API_URL,
        secure: false
    });
    app.use(appProxy);
};