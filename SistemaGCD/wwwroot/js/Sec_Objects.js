var app = new Vue({
    el: '#app',
    data: {
        modalVisibility: 'none',
        disabledButton: false,
        sec_objects: [],
        selectedSec_Object: {},
        editSec_Object: '',
        gridSec_Object: '',
        inputErrors: [],
        Objects_Types: []
    },

    mounted: function () {

    },

    created: function () {
        var self = this;
        self.getActions();
        self.getObject_Type();
    },

    methods: {
        getActions: function () {
            fetch('./api/Sec_Objects/getall')
                .then(function (response) {
                    if (response.status !== 200) {
                        console.log('Looks like there was a problem. Status Code: ' + response.status);
                        return;
                    }
                    response.json().then(function (data) {
                        app.sec_objects = data;
                    });
                }
                )
                .catch(function (err) {
                    console.log('Fetch Error :-S', err);
                });
        },

        getObject_Type: function () {
            fetch('./api/Object_Type/getall')
                .then(function (response) {
                    if (response.status !== 200) {
                        console.log('Looks like there was a problem. Status Code: ' + response.status);
                        return;
                    }
                    response.json().then(function (data) {
                        app.Objects_Types = data;
                    });
                }
                )
                .catch(function (err) {
                    console.log('Fetch Error :-S', err);
                });
        },

        openEditModal: function (action, mode) {
            app.modalVisibility = "block"
            app.editSec_Object = mode
            if (mode == "EDIT") {
                app.selectedSec_Object = Object.assign({}, action)
            }
            if (mode == "NEW") {
                app.selectedSec_Object = { name: '', description: '' }
            }
        },
        closeModal: function () {
            app.modalVisibility = "none"
        },

        validateActionInput: function () {
            app.inputErrors = []
            if (app.selectedSec_Object.name == '') {
                app.inputErrors.push('El nombre no debe ser vacío!')
            }
            if (app.selectedSec_Object.description == '') {
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
            if (app.editSec_Object == "EDIT") {
                res = '/api/Sec_Objects/Update'
            }
            if (app.editSec_Object == "NEW") {
                res = '/api/Sec_Objects/Create'
            }
            fetch(res, {
                method: 'post',
                headers: {
                    "Content-Type": "application/json"
                },
                body: JSON.stringify(app.selectedSec_Object)
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
            app.selectedSec_Object = Object.assign({}, action)
            Vue.nextTick(function () {
                //Esto se ejecuta en la proxima iteracion de dibujado de elementos en el DOM.
                if (!confirm("¿Está seguro de eliminar?")) {
                    app.closeModal()
                    return;
                }
                fetch('/api/Sec_Objects/delete', {
                    method: 'post',
                    headers: {
                        "Content-Type": "application/json"
                    },
                    body: JSON.stringify(app.selectedSec_Object)
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

        },

    }
})