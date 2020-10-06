const path = require('path');
const HtmlWebPackPlugin = require("html-webpack-plugin");
const webpack = require('webpack');


// Constant with our paths
const paths = {
    DIST: path.resolve(__dirname, 'dist/'),
    SRC: path.resolve(__dirname, 'src/'), // source folder path -> ADDED IN THIS STEP
    Pub: path.resolve(__dirname,'public/'),
  };

module.exports = {
    entry: path.join(paths.SRC, 'index.js'),
    output: {
        path: paths.DIST,
        filename: 'app.bundle.js'
    },    
    resolve: {
        extensions: ['.js', '.jsx', '.json', '.ejs', '.web'],
    }, 
    // Dev server configuration -> ADDED IN THIS STEP
    // Now it uses our "src" folder as a starting point
    devServer: {
        contentBase: paths.SRC,
    },    
    module: {
      rules: [
        {
          test: /\.(js|jsx)$/,
          exclude: /node_modules|bower_components/,    
          include: paths.SRC,
          use: {
            loader: "babel-loader",
            options: { presets: ['@babel/preset-react', '@babel/preset-env'] }
          },  
        },
        { 
            test: /\.css$/, 
            use: ["style-loader", "css-loader"] 
        },
        {
            test: /\.html$/,
            use: [
              {
                loader: "html-loader"
              }
            ]
        },
        {
          test: /.(ttf|otf|eot|svg|woff(2)?)(\?[a-z0-9]+)?$/, // For Font Awesome 
          use: [{
              loader: 'file-loader',
              options: {
                  name: '[name].[ext]',
                  outputPath: 'fonts/',    // where the fonts will go
              }
          }]
        }, 
        {
          test: /\.(gif|png|jpe?g|svg)$/,
          use: [
                  {
                    loader: 'file-loader',
                    options: { name: 'file?name=[name].[ext]', }
                  }
              ]
        },    
      ]
    },
    plugins: [
        new HtmlWebPackPlugin({
          template: path.join(paths.Pub, 'index.html'), 
          filename: "index.html"
        }),
        new webpack.ProvidePlugin({
          $: "jquery",
          jQuery: "jquery",
          "window.jQuery": "jquery"
        })
    ]
};