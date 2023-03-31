
var app = new Vue({
    el: '#app',
    mounted: function () {
        this.setUp()
    },
    computed: {
        isLoadCompleted()
        {
            return this.color.load_completed
        },
        hasError()
        {
            return this.color.error.has
        },
    },
    methods: {
        setUp()
        {
            this.color.load_completed = false

            axios.get('/api/v1/ColorSpec/All/')
                .then(function (response) {
                    if(response.data.Message.Status == 0)
                    {
                        this.color.specs = response.data.Specs

                        this.color.load_completed = true
                    }
                    else
                    {
                        this.clearError()
                        this.color.error.has = true
                        this.color.error.message = `色情報取得エラー: ${response.data.Message.Message}`
                    }
                }.bind(this))
        },
        clearError: function()
        {
            this.color.error.message = ""
        },
        hideError: function() {
            this.color.error.has = false
        },
    },
    data: {
        color: {
            load_completed: false,
            specs: null,
            error: {
                has: false,
                message: "",
            },
        },
    }
})
