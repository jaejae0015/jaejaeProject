module.exports = {
    "root": true,
    "env": {
        "browser": true,
        "es2021": true
    },
    "extends": [
        //"standard-with-typescript",
        //"plugin:vue/vue3-essential",
        "plugin:vue/vue3-recommended",
        "eslint:recommended"
    ],
     "overrides": [
         {
             "env": {
                 "node": true
             },
             "files": [
                 ".eslintrc.{js,cjs}"
             ],
             "parserOptions": {
                 "sourceType": "script"
             }
         }
    ],
    "parserOptions": {
        "parser":'@babel/eslint-parser',
        "ecmaVersion": "latest",
        "sourceType": "module"
    },
    "plugins": [
        "vue"
    ],
    "rules": {
    }
}
