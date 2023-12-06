# frontjeck

## 프로젝트 생성
- bootstrapVue를 쓴다면 버전 2로 생성해야함.
- 아래의 명령어 대로 설치 할 것 (router버전 포함)
```
--vue 버전 2설치
npm install vue@2
npm install vue@2.6.14

--router

npm install vue-router@3.5.3
npm install vuex@3.6.2

--프로젝트 생성
npm install -g @vue/cli
vue create 프로젝트명

[참고] https://velog.io/@integer/Vue.js-%EC%8B%9C%EC%9E%91%ED%95%98%EA%B8%B0

```

## ESLint 설정 및 bootstrapVue 설정
```
--bootstrapVue 설정
npm install vue bootstrap bootstrap-vue

main.js에 코드 넣어주기[참고] https://bootstrap-vue.org/docs

--ESLint 설정

npm install -g eslint
npm install --save-dev @babel/eslint-parser
npm install --save-dev eslint eslint-plugin-vue

eslint --init

--이때 생성되는 .eslintrc.js에서 //"standard-with-typescript"를 주석


## Project setup
```
npm install
```

### Compiles and hot-reloads for development
```
npm run serve
```

### Compiles and minifies for production
```
npm run build
```

### Lints and fixes files
```
npm run lint
```

