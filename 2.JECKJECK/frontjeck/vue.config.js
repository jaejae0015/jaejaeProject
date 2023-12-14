//const { defineConfig } = require('@vue/cli-service')
// module.exports = defineConfig({
//   transpileDependencies: true
// })

//CORS 에러 처리
module.exports = {
  devServer: {
      proxy: {
          '/api': {
              target: 'http://localhost:8080'
          }
      }
  }
}
