var app = new Vue({
    el: '#app',
    data: {
        modalVisibility: 'none',
        disabledButton: false,
        companys: [],
        suscriptions: [],
        selectedCompany: {},
        editModCompany: '',
        gridCompany: '',
        inputErrors: []
    },

    mounted: function () {

    },

    created: function () {
        var self = this;
        self.getSuscription();

    },

    methods: {
           getSuscription: function () {
            fetch('./api/Suscription/getall')
                .then(function (response) {
                    if (response.status !== 200) {
                        console.log('Looks like there was a problem. Status Code: ' + response.status);
                        return;
                    }
                    response.json().then(function (data) {
                        app.suscriptions = data;
                    });
                }
                )
                .catch(function (err) {
                    console.log('Fetch Error :-S', err);
                });
        },

        validateActionInput: function () {
            app.inputErrors = []
            if (app.selectedCompany.name == '') {
                app.inputErrors.push('El nombre no debe ser vacío!')
            }
            if (app.selectedCompany.description == '') {
                app.inputErrors.push('Ingrese una descripcion!');
            }
            if (app.selectedCompany.phone == '' || isNaN(app.selectedCompany.phone)) {
                app.inputErrors.push('Ingrese un numero de Telefono o Campo Valida!');
            }
            if (app.selectedCompany.email == '') {
                app.inputErrors.push('Ingrese un Email!!');
            }

        },

        saveEdit: function () {
            var res = ''
            res = '/api/Company/create'
            //validar
            //app.validateActionInput();
            //if (app.inputErrors.length > 0) {
            //    return;
            //}
            //if (app.editModCompany == "EDIT") {
            //    res = '/api/Company/update'
            //}
            //if (app.editModCompany == "NEW") {
            //    res = '/api/Company/create'
            //}
            fetch(res, {
                method: 'post',
                headers: {
                    "Content-Type": "application/json"
                },
                body: JSON.stringify(app.selectedCompany)
            })
                .then(function (r) {
                    return r.json()
                })
                .then(function (data) {
                    alert("Compania Registrada Con Exito")
                    window.location.href = "/Login.html"
                })
                .catch(function (error) {
                    console.log('Request failed', error);
                });
        },

         }
    
})