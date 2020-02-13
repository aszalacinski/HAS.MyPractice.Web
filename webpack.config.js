const path = require('path');
const MiniCssExtractPlugin = require('mini-css-extract-plugin');

module.exports = (env, arg) => {
    return {
        mode: "development",
        entry: ['./Scripts/css/styles.css', './Scripts/ts/App.ts'],
        output: {
            filename: 'site.js',
            path: path.resolve(__dirname, './wwwroot/js')
        },
        devtool: 'inline-source-map',
        module: {
            rules: [
                {
                    test: /\.ts$/,
                    use: 'ts-loader',
                    exclude: /node_modules/
                },
                {
                test: /\.css$/,
                exclude: /node_modules/,
                use: [
                    MiniCssExtractPlugin.loader,
                    'css-loader',
                    'postcss-loader'
                ]
            }]
        },
        plugins: [
            new MiniCssExtractPlugin({
                filename: '../css/site.css'
            })
        ],
        resolve: {
            extensions: ['.ts', '.js']
        }
    };
};