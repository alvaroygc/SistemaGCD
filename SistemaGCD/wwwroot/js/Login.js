var app = new Vue({
    el: '#app',
    data: {
        modalVisibility: 'block',
        disabledButton: false,
        actions: [],
        selectedAction: {},
        editModAction: '',
        gridAction: '',
        inputErrors: []
    },

    mounted: function () {

    },

    created: function () {
        var self = this;
        self.getActions();
    },

    methods: {
        getActions: function () {
            fetch('./api/Allowed_action/getall')
                .then(function (response) {
                    if (response.status !== 200) {
                        console.log('Looks like there was a problem. Status Code: ' + response.status);
                        return;
                    }
                    response.json().then(function (data) {
                        app.actions = data;
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
            app.validateActionInput();
            if (app.inputErrors.length > 0) {
                return;
            }
            if (app.editModAction == "EDIT") {
                res = '/api/Allowed_action/update'
            }
            if (app.editModAction == "NEW") {
                res = '/api/Allowed_action/create'
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
                    app.getActions()
                })
                .catch(function (error) {
                    console.log('Request failed', error);
                });
        },

        DeleteAction: function (action) {
            app.modalVisibility = "block"
            app.selectedAction = Object.assign({}, action)
            Vue.nextTick(function () {
                //Esto se ejecuta en la proxima iteracion de dibujado de elementos en el DOM.
                if (!confirm("¿Está seguro de eliminar?")) {
                    app.closeModal()
                    return;
                }
                fetch('/api/Allowed_action/Delete', {
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
                        app.getActions()
                    })
                    .catch(function (error) {
                        console.log('Request failed', error);
                    });
            })
        }
    }
})