const path = require('path');
const TerserJSPlugin = require('terser-webpack-plugin');
const MiniCssExtractPlugin = require('mini-css-extract-plugin');
const OptimizeCSSAssetsPlugin = require('optimize-css-assets-webpack-plugin');

module.exports = (env, arg) => {
    return {
        mode: arg.mode === "production" ? "production" : "development",
        entry: ['./Scripts/css/styles.css', './Scripts/ts/App.ts'],
        output: {
            filename: 'site.js',
            path: path.resolve(__dirname, './wwwroot/js')
        },
        devtool: arg.mode === "production" ? 'none' : 'inline-source-map',
        optimization: {
            minimizer: arg.mode === "production" ? [new TerserJSPlugin({}), new OptimizeCSSAssetsPlugin({})] : []
        },
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