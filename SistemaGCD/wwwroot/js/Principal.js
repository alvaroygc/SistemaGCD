var app = new Vue({
    el: '#app',
    mixins: [AutMixin],
    data: {
        modalVisibility: 'none',
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
        
    },

    methods: {
        
    }
})