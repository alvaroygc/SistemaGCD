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
        self.getCompany();
        self.getSuscription();
        
    },

    methods: {
        getCompany: function () {
            fetch('./api/Company/getall')
                .then(function (response) {
                    if (response.status !== 200) {
                        console.log('Looks like there was a problem. Status Code: ' + response.status);
                        return;
                    }
                    response.json().then(function (data) {
                        app.companys = data;
                    });
                }
                )
                .catch(function (err) {
                    console.log('Fetch Error :-S', err);
                });
        },

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

        openEditModal: function (action, mode) {
            app.modalVisibility = "block"
            app.editModCompany = mode
            if (mode == "EDIT") {
                app.selectedCompany = Object.assign({}, action)
            }
            if (mode == "NEW") {
                app.selectedCompany = { name: '', description: '' }
            }
        },
        closeModal: function () {
            app.modalVisibility = "none"
        },

        validateActionInput: function () {
            app.inputErrors = []
            if (app.selectedCompany.name == '') {
                app.inputErrors.push('El nombre no debe ser vacío!')
            }
            if (app.selectedCompany.description == '') {
                app.inputErrors.push('Ingrese una descripcion!');
            }
        },

        saveEdit: function () {
            var res = ''
            //validar
           // app.validateActionInput();
            if (app.inputErrors.length > 0) {
                return;
            }
            if (app.editModCompany == "EDIT") {
                res = '/api/Company/update'
            }
            if (app.editModCompany == "NEW") {
                res = '/api/Company/create'
            }
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
                    app.closeModal()
                    app.getCompany()
                })
                .catch(function (error) {
                    console.log('Request failed', error);
                });
        },

        DeleteCompany: function (action) {
            app.modalVisibility = "block"
            app.selectedCompany = Object.assign({}, action)
            Vue.nextTick(function () {
                //Esto se ejecuta en la proxima iteracion de dibujado de elementos en el DOM.
                if (!confirm("¿Está seguro de eliminar?")) {
                    app.closeModal()
                    return;
                }
                fetch('/api/Company/Delete', {
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
                        //alert(data.result)
                        app.closeModal()
                        app.getCompany()
                    })
                    .catch(function (error) {
                        console.log('Request failed', error);
                    });
            })
        }
    }
})