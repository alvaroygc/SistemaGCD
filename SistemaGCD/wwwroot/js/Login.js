//var cryptobject;
var app = new Vue({
    el: '#app',
    data: {
        modalVisibility: 'none',
        disabledButton: false,
        users: [],
        selectedUsers: {},
        editModUsers: '',
        gridUsers: '',
        inputErrors: [],
        secondFactor: false,
        encryptsecret: 'S3curit!P@55'
    },

    mounted: function () {

    },

    created: function () {
        var self = this;
    },

    //computed: {
    //    decrypted: function () {
    //        return (this.encrypted ? CryptoJS.AES.decrypt(this.encrypted.str, this.decryptsecret).toString(CryptoJS.enc.Latin1) : 'fred');
    //    }
    //},

    methods: {  

        encrypt: function () {
            cryptobject = CryptoJS.AES.encrypt(app.selectedUsers.pass, this.encryptsecret);
            this.encrypted = {
                key: cryptobject.key + '', // don't send this
                iv: cryptobject.iv + '', // don't send this
                salt: cryptobject.salt + '', // don't send this
                ciphertext: cryptobject.ciphertext + '', // don't send this
                str: cryptobject + '' // send or store this
            }
        },

        login: function () {      
            var res = ''
            res = './api/Access/Login'
           // this.encrypt()
            fetch(res, {
                method: 'post',
                headers: {
                    "Content-Type": "application/json",
                    "LoggedUser": sessionStorage.getItem("Id")
                },
                body: JSON.stringify(app.selectedUsers)
                //    {
                //    email: app.selectedusers.email,
                //    pass: this.encrypted.str
                //})
            })
             
                .then(function (r) {
                    return r.json()
                    alert(r);
                 })
                .then(function (data) {
                   
                    if (!data.result[0].id) {
                        alert('Error al iniciar sesion');
                        return;
                    }
                    if (data.result[0].id * 1 <= 0) { 
                        alert('Error al iniciar sesion');
                        return;
                    }
                    sessionStorage.setItem("Id", data.result[0].id);
                    sessionStorage.setItem("Name", data.result[0].name);
                    sessionStorage.setItem("Id_Company", data.result[0].id_Company);     
                    window.location.href = "/Token.html"
                                       
                })
                .catch(function (error) {
                    console.log('Request failed', error);
                    alert('Contraseña o Correo Incorrecto');
                });
        }, 

       
        tokenVerify: function () {
            var res = ''
            res = './api/Access/Token'

            fetch(res, {
                method: 'post',
                headers: {
                    "Content-Type": "application/json",
                    "LoggedUser": sessionStorage.getItem("Id")
                },
                body: JSON.stringify(app.selectedUsers)
            })

                .then(function (r) {
                    return r.json()
                })
                .then(function (data) {
                        if (!data.result[0].id) {
                        alert('Error al iniciar sesion');
                        return;
                    }
                    if (data.result[0].id * 1 <= 0) {
                        alert('Error al iniciar sesion');
                        return;
                    }
                    window.location.href = "/Principal.html"
                   

                })
                .catch(function (error) {
                    console.log('Request failed', error);
                    alert('Token Incorrecto')
                });
        }
    }
})