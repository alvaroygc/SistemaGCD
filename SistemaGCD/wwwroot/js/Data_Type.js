var app = new Vue({
    el: '#app',
    mixins: [AutMixin],
    data: {
        modalVisibility: 'none',
        disabledButton: false,
        data_types: [],
        selectedData_Types: {},
        editModData_Type: '',
        gridData_Type: '',
        inputErrors: []
    },

    mounted: function () {

    },

    created: function () {
        var self = this;
        self.getData_Types();
    },

    methods: {
        getData_Types: function () {
            fetch('./api/Data_Type/getall')
                .then(function (response) {
                    if (response.status !== 200) {
                        console.log('Looks like there was a problem. Status Code: ' + response.status);
                        return;
                    }
                    response.json().then(function (data) {
                        app.data_types = data;
                    });
                }
                )
                .catch(function (err) {
                    console.log('Fetch Error :-S', err);
                });
        },

        openEditModal: function (action, mode) {
            app.modalVisibility = "block"
            app.editModData_Type = mode
            if (mode == "EDIT") {
                app.gridData_Type = "Editar";
                app.selectedData_Types = Object.assign({}, action)
            }
            if (mode == "NEW") {
                app.gridData_Type = "Nuevo";
                app.selectedData_Types = { name: '', description: '' }
            }
        },
        closeModal: function () {
            app.modalVisibility = "none"
        },

        validateActionInput: function () {
            app.inputErrors = []
            if (app.selectedData_Types.name == '') {
                app.inputErrors.push('El nombre no debe ser vacío!')
            }
            if (app.selectedData_Types.description == '') {
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
            if (app.editModData_Type == "EDIT") {
                res = '/api/Data_Type/update'
            }
            if (app.editModData_Type == "NEW") {
                res = '/api/Data_Type/create'
            }
            fetch(res, {
                method: 'post',
                headers: {
                    "Content-Type": "application/json"
                },
                body: JSON.stringify(app.selectedData_Types)
            })
                .then(function (r) {
                    return r.json()
                })
                .then(function (data) {
                    app.closeModal()
                    app.getData_Types()
                })
                .catch(function (error) {
                    console.log('Request failed', error);
                });
        },

        DeleteData_Type: function (action) {
            app.modalVisibility = "block"
            app.selectedData_Types = Object.assign({}, action)
            Vue.nextTick(function () {
                //Esto se ejecuta en la proxima iteracion de dibujado de elementos en el DOM.
                if (!confirm("¿Está seguro de eliminar?")) {
                    app.closeModal()
                    return;
                }
                fetch('/api/Data_Type/Delete', {
                    method: 'post',
                    headers: {
                        "Content-Type": "application/json"
                    },
                    body: JSON.stringify(app.selectedData_Types)
                })
                    .then(function (r) {
                        return r.json()
                    })
                    .then(function (data) {
                        //alert(data.result)
                        app.closeModal()
                        app.getData_Types()
                    })
                    .catch(function (error) {
                        console.log('Request failed', error);
                    });
            })
        }
    }
})