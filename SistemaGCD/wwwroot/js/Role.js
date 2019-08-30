var app = new Vue({
    el: '#app',
    data: {
        modalVisibility: 'none',
        disabledButton: false,
        roles: [],
        selectedRoles: {},
        editModRoles: '',
        gridRoles: '',
        inputErrors: []
    },

    mounted: function () {

    },

    created: function () {
        var self = this;
        self.getRoless();
    },

    methods: {
        getRoless: function () {
            fetch('./api/roles/getall')
                .then(function (response) {
                    if (response.status !== 200) {
                        console.log('Looks like there was a problem. Status Code: ' + response.status);
                        return;
                    }
                    response.json().then(function (data) {
                        app.roles = data;
                    });
                }
                )
                .catch(function (err) {
                    console.log('Fetch Error :-S', err);
                });
        },

        openEditModal: function (action, mode) {
            app.modalVisibility = "block"
            app.editModRoles = mode
            if (mode == "EDIT") {
                app.selectedRoles = Object.assign({}, action)
            }
            if (mode == "NEW") {
                app.selectedRoles = { name: '', description: '' }
            }
        },
        closeModal: function () {
            app.modalVisibility = "none"
        },

        validateRolesInput: function () {
            app.inputErrors = []
            if (app.selectedRoles.name == '') {
                app.inputErrors.push('El nombre no debe ser vacío!')
            }
            if (app.selectedRoles.description == '') {
                app.inputErrors.push('Ingrese una descripcion!');
            }
        },

        saveEdit: function () {
            var res = ''
            //validar
            //  app.validateRolesInput();
            if (app.inputErrors.length > 0) {
                return;
            }
            if (app.editModRoles == "EDIT") {
                res = '/api/roles/update'
            }
            if (app.editModRoles == "NEW") {
                res = '/api/roles/create'
            }
            fetch(res, {
                method: 'post',
                headers: {
                    "Content-Type": "application/json"
                },
                body: JSON.stringify(app.selectedRoles)
            })
                .then(function (r) {
                    return r.json()
                })
                .then(function (data) {
                    app.closeModal()
                    app.getRoless()
                })
                .catch(function (error) {
                    console.log('Request failed', error);
                });
        },

        DeleteRoles: function (action) {
            app.modalVisibility = "block"
            app.selectedRoles = Object.assign({}, action)
            Vue.nextTick(function () {
                //Esto se ejecuta en la proxima iteracion de dibujado de elementos en el DOM.
                if (!confirm("¿Está seguro de eliminar?")) {
                    app.closeModal()
                    return;
                }
                fetch('/api/roles/delete', {
                    method: 'post',
                    headers: {
                        "Content-Type": "application/json"
                    },
                    body: JSON.stringify(app.selectedRoles)
                })
                    .then(function (r) {
                        return r.json()
                    })
                    .then(function (data) {
                        //alert(data.result)
                        app.closeModal()
                        app.getRoles()
                    })
                    .catch(function (error) {
                        console.log('Request failed', error);
                    });
            })
        }
    }
})