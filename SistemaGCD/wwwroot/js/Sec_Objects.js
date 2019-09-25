var app = new Vue({
    el: '#app',
    mixins: [AutMixin],
    data: {
        modalVisibility: 'none',
        disabledButton: false,
        sec_objects: [],
        selectedSec_Objects: {},
        editModSec_Objects: '',
        gridSec_Objects: '',
        inputErrors: []
    },

    mounted: function () {

    },

    created: function () {
        var self = this;
        self.getSec_Objects();
    },

    methods: {
        getSec_Objects: function () {
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

        openEditModal: function (action, mode) {
            app.modalVisibility = "block"
            app.editModSec_Objects = mode
            if (mode == "EDIT") {
                app.gridSec_Objects = "Editar";
                app.selectedSec_Objects = Object.assign({}, action)
            }
            if (mode == "NEW") {
                app.gridSec_Objects = "Nuevo";
                app.selectedSec_Objects = { name: '', description: '' }
            }
        },
        closeModal: function () {
            app.modalVisibility = "none"
        },

        validateActionInput: function () {
            app.inputErrors = []
            if (app.selectedSec_Objects.name == '') {
                app.inputErrors.push('El nombre no debe ser vacío!')
            }
            if (app.selectedSec_Objects.description == '') {
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
            if (app.editModSec_Objects == "EDIT") {
                res = '/api/Sec_Objects/update'
            }
            if (app.editModSec_Objects == "NEW") {
                res = '/api/Sec_Objects/create'
            }
            fetch(res, {
                method: 'post',
                headers: {
                    "Content-Type": "application/json"
                },
                body: JSON.stringify(app.selectedSec_Objects)
            })
                .then(function (r) {
                    return r.json()
                })
                .then(function (data) {
                    app.closeModal()
                    app.getSec_Objects()
                })
                .catch(function (error) {
                    console.log('Request failed', error);
                });
        },

        DeleteSec_Objects: function (action) {
            app.modalVisibility = "block"
            app.selectedSec_Objects = Object.assign({}, action)
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
                    body: JSON.stringify(app.selectedSec_Objects)
                })
                    .then(function (r) {
                        return r.json()
                    })
                    .then(function (data) {
                        //alert(data.result)
                        app.closeModal()
                        app.getSec_Objects()
                    })
                    .catch(function (error) {
                        console.log('Request failed', error);
                    });
            })
        }
    }
})