import Vue from 'vue'
import App from './App.vue'
import router from '@/routes/index';



/* 부트스트랩 관련 설정 */
import { BootstrapVue, IconsPlugin } from 'bootstrap-vue'
import 'bootstrap/dist/css/bootstrap.css'
import 'bootstrap-vue/dist/bootstrap-vue.css'
Vue.use(BootstrapVue)
Vue.use(IconsPlugin)


Vue.config.productionTip = false

new Vue({
  render: h => h(App),
  router, //export로 생성한 routes 인스턴스를 연결
}).$mount('#app')
