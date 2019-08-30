var app = new Vue({
    el: '#app',
    data: {
        modalVisibility: 'none',
        disabledButton: false,
        object_type: [],
        selectedObject_type: {},
        editModObject_type: '',
        gridObject_type: '',
        inputErrors: []
    },

    mounted: function () {

    },

    created: function () {
        var self = this;
        self.getObject_types();
    },

    methods: {
        getObject_types: function () {
            fetch('./api/Object_Type/getall')
                .then(function (response) {
                    if (response.status !== 200) {
                        console.log('Looks like there was a problem. Status Code: ' + response.status);
                        return;
                    }
                    response.json().then(function (data) {
                        app.object_type = data;
                    });
                }
                )
                .catch(function (err) {
                    console.log('Fetch Error :-S', err);
                });
        },

        openEditModal: function (action, mode) {
            app.modalVisibility = "block"
            app.editModObject_type = mode
            if (mode == "EDIT") {
                app.selectedObject_type = Object.assign({}, action)
            }
            if (mode == "NEW") {
                app.selectedObject_type = { name: '', description: '' }
            }
        },
        closeModal: function () {
            app.modalVisibility = "none"
        },

        ValidateObject_typeInput: function () {
            app.inputErrors = []
            if (app.selectedObject_type.name == '') {
                app.inputErrors.push('El nombre no debe ser vacío!')
            }
            if (app.selectedObject_type.description == '') {
                app.inputErrors.push('Ingrese una descripcion!');
            }
        },

        saveEdit: function () {
            var res = ''
            //Validar Inputs
            app.ValidateObject_typeInput();
            if (app.inputErrors.length > 0) {
                return;
            }
            if (app.editModObject_type == 'EDIT') {
                res = '/api/Object_Type/update'
            }
            if (app.editModObject_type == 'NEW') {
                res = '/api/Object_Type/create'
            }
            fetch(res, {
                method: 'post',
                headers: {
                    "Content-Type": "application/json"
                },
                body: JSON.stringify(app.selectedObject_type)
            })
                .then(function (r) {
                    return r.json()
                })
                .then(function (data) {
                    app.closeModal()
                    app.getObject_types()
                })
                .catch(function (error) {
                    console.log('Request failed', error);
                });
        },

        DeleteObject_type: function (action) {
            app.modalVisibility = "block"
            app.selectedObject_type = Object.assign({}, action)
            Vue.nextTick(function () {
                //Esto se ejecuta en la proxima iteracion de dibujado de elementos en el DOM.
                if (!confirm("¿Está seguro de eliminar?")) {
                    app.closeModal()
                    return;
                }
                fetch('/api/Object_Type/delete', {
                    method: 'post',
                    headers: {
                        "Content-Type": "application/json"
                    },
                    body: JSON.stringify(app.selectedObject_type)
                })
                    .then(function (r) {
                        return r.json()
                    })
                    .then(function (data) {
                        //alert(data.result)
                        app.closeModal()
                        app.getObject_types()
                    })
                    .catch(function (error) {
                        console.log('Request failed', error);
                    });
            })
        }
    }
})

