const PROXY_CONFIG = [
    {
        context: [
            "/api/*"
        ],
        "target": "http://devcourses.alsde.edu",
        "secure": false,
        "changeOrigin": true,
        "logLevel": "debug"
    }
];

module.exports = PROXY_CONFIG;