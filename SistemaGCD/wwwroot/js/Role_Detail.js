var app = new Vue({
    el: '#app',
    mixins: [AutMixin],
    data: {
        modalVisibility: 'none',
        disabledButton: false,
        details: [],
        selectedAction: {},
        editModAction: '',
        gridDetails: '',
        inputErrors: [],
        Objects: [],
        Roles: [],
        Allowed_Actions: []
    },

    mounted: function () {

    },

    created: function () {
        var self = this;
        self.getDetails();
        self.getRole();
        self.getSec_Objects();
        self.getAllowed_Actions();
    },

    methods: {
        getDetails: function () {
            fetch('./api/Role_Detail/getall')
                .then(function (response) {
                    if (response.status !== 200) {
                        console.log('Looks like there was a problem. Status Code: ' + response.status);
                        return;
                    }
                    response.json().then(function (data) {
                        app.details = data;
                    });
                }
                )
                .catch(function (err) {
                    console.log('Fetch Error :-S', err);
                });
        },



        getRole: function () {
            fetch('./api/Roles/getall')
                .then(function (response) {
                    if (response.status !== 200) {
                        console.log('Looks like there was a problem. Status Code: ' + response.status);
                        return;
                    }
                    response.json().then(function (data) {
                        app.Roles = data;
                    });
                }
                )
                .catch(function (err) {
                    console.log('Fetch Error :-S', err);
                });
        },
        getSec_Objects: function () {
            fetch('./api/sec_objects/getall')
                .then(function (response) {
                    if (response.status !== 200) {
                        console.log('Looks like there was a problem. Status Code: ' + response.status);
                        return;
                    }
                    response.json().then(function (data) {
                        app.Objects = data;
                    });
                }
                )
                .catch(function (err) {
                    console.log('Fetch Error :-S', err);
                });
        },

        getAllowed_Actions: function () {
            fetch('./api/allowed_action/getall')
                .then(function (response) {
                    if (response.status !== 200) {
                        console.log('Looks like there was a problem. Status Code: ' + response.status);
                        return;
                    }
                    response.json().then(function (data) {
                        app.Allowed_Actions = data;
                    });
                }
                )
                .catch(function (err) {
                    console.log('Fetch Error :-S', err);
                });
        },

        openEditModal: function (action, mode) {
            app.modalVisibility = "block"
            app.editModAction = mode
            if (mode == "EDIT") {
                app.selectedAction = Object.assign({}, action)
            }
            if (mode == "NEW") {
                app.selectedAction = { name: '', description: '' }
            }
        },
        closeModal: function () {
            app.modalVisibility = "none"
        },

        validateActionInput: function () {
            app.inputErrors = []
            if (app.selectedAction.name == '') {
                app.inputErrors.push('El nombre no debe ser vacío!')
            }
            if (app.selectedAction.description == '') {
                app.inputErrors.push('Ingrese una descripcion!');
            }
        },

        saveEdit: function () {
            var res = ''
            //validar
            //  app.validateActionInput();
            if (app.inputErrors.length > 0) {
                return;
            }
            if (app.editModAction == "EDIT") {
                res = '/api/Role_Detail/update'
            }
            if (app.editModAction == "NEW") {
                res = '/api/Role_Detail/create'
            }
            fetch(res, {
                method: 'post',
                headers: {
                    "Content-Type": "application/json"
                },
                body: JSON.stringify(app.selectedAction)
            })
                .then(function (r) {
                    return r.json()
                })
                .then(function (data) {
                    app.closeModal()
                    app.getDetails()
                })
                .catch(function (error) {
                    console.log('Request failed', error);
                });
        },

        DeleteDetails: function (action) {
            app.modalVisibility = "block"
            app.selectedAction = Object.assign({}, action)
            Vue.nextTick(function () {
                //Esto se ejecuta en la proxima iteracion de dibujado de elementos en el DOM.
                if (!confirm("¿Está seguro de eliminar?")) {
                    app.closeModal()
                    return;
                }
                fetch('/api/Role_Detail/delete', {
                    method: 'post',
                    headers: {
                        "Content-Type": "application/json"
                    },
                    body: JSON.stringify(app.selectedAction)
                })
                    .then(function (r) {
                        return r.json()
                    })
                    .then(function (data) {
                        //alert(data.result)
                        app.closeModal()
                        app.getDetails()
                    })
                    .catch(function (error) {
                        console.log('Request failed', error);
                    });
            })

        },

    }
})