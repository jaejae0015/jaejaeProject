import  Vue from 'vue';
import VueRouter from 'vue-router';

//코드스플리팅 적용으로 그때 그때 가져올 수 있도록 변경하여 주석처리함.
//import LoginPage from '@/Views/LoginPage.vue';
//import SignupPage from '@/Views/SignupPage.vue';

// Vue.use를 통해서 플러그인 초기화
Vue.use(VueRouter);

// export는 밖에서 인스턴스를 쓰기 위해서.
//페이지 라우팅 처리
export default new VueRouter({  
    //운영배포시에는 해당 mode와 관련하여 문서 확인 필수
    mode:'history', //url 상에 #이 제거되도록 설정 - #을 이용해서 새로운 페이지가 아님을 인지
    routes:[
        // {
        //     path:"/",
        //     redirect:"/login"
        // },
        {
            path:'/login',
            //component:LoginPage
            //코드스플리팅 적용-필요할때마다 파일을 들고오는 형식
            component: () => import("@/Views/LoginPage.vue")
        },
        {
            path:'/signup',
            //component:SignupPage,
            //코드스플리팅 적용-필요할때마다 파일을 들고오는 형식
            component: () => import("@/Views/SignupPage.vue")
        },
        {
            //Exception 페이지 처리
            path:"*",//정의하진 모든 url에 대해 처리하겠다.
            component: () => import("@/Views/NotFountPage.vue")
        }
    ]
});