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
        secondFactor: false
    },

    mounted: function () {

    },

    created: function () {
        var self = this;
    },

    methods: {      
        login: function () {      
            var res = ''                
                res = './api/Access/Login'
            
            fetch(res, {
                method: 'post',
                headers: {
                    "Content-Type": "application/json"
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
                    window.location.href = "/Token.html"
                    localStorage.setItem("Id", data.result[0].id);
                    localStorage.setItem("Name", data.result[0].name);
                    localStorage.setItem("Id_Company", data.result[0].id_Company);                   
                })
                .catch(function (error) {
                    console.log('Request failed', error);
                });
        },  
        tokenVerify: function () {
            var res = ''
            res = './api/Access/Token'

            fetch(res, {
                method: 'post',
                headers: {
                    "Content-Type": "application/json"
                },
                body: JSON.stringify(app.selectedUsers)
            })

                .then(function (r) {
                    return r.json()
                })
                .then(function (data) {
                    alert(JSON.stringify(data))
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
                });
        }
    }
})