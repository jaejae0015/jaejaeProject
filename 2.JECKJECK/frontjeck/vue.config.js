//const { defineConfig } = require('@vue/cli-service')
// module.exports = defineConfig({
//   transpileDependencies: true
// })

//CORS 에러 처리
module.exports = {
    outputDir:"../BackEndJeck/src/main/resources/static"
    ,devServer: {
      proxy: {
          '/api': {
              target: 'http://localhost:8080',
              changeOrigin:true
          }
      }
  }
}
