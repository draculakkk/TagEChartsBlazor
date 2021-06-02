



window.echartsFunctions = {
    map: new Map(),
    themes: [],
    getChartTheme: function (id, theme) {
        if (this.themes.some(r => r == theme)) {
            if (!this.map.has(`${id}_theme`) || this.map.get(`${id}_theme`) != theme || !this.map.has(id)) {
                echarts.dispose(echarts.init(document.getElementById(id)));
                this.map.set(id, echarts.init(document.getElementById(id), theme));
                this.map.set(`${id}_theme`, theme);
            }
        }
        else {
            this.map.set(id, echarts.init(document.getElementById(id)));
        }

        return this.map.get(id);
    },
    getChart: function (id) {
        if (!this.map.has(id)) {
            console.error(`echarts id:${id} lost!`);
            this.map.set(id, echarts.init(document.getElementById(id)));
        }

        return this.map.get(id);
    },
    initChartsAll: function (id, theme, group, debugModel, option) {

        try {
            this.formatOption(option);

            if (debugModel) {
                //debug
                console.log(option);
            }

            var myChart = this.getChartTheme(id, theme);
            if (group != null && group != "" && (!myChart.hasOwnProperty("group") || myChart.group != group)) {
                myChart.group = group;
            }
            // 使用刚指定的配置项和数据显示图表。
            myChart.setOption(option);
        }
        catch (e) {
            console.error(e);
        }
    },
    formatOption: function (option) {
        if (option == null || option == undefined) {
            return;
        }

        for (let p in option) {
            if (Array.isArray(option[p])) {
                this.formatOption(option[p]);
            }

            if (Object.prototype.toString.call(option[p]) === '[object Object]') {
                if (option[p] != null && option[p].hasOwnProperty("disableRender") && option[p].disableRender) {
                    delete option[p];
                }
                else {
                    this.formatOption(option[p]);
                }
            }

            if (p == "image" && option[p] != null) {
                var img = new Image();
                img.src = option[p];
                option[p] = img;
            }

            if (typeof (option[p]) == 'string') {
                if (option[p] == "null") {
                    option[p] = null;
                }
                else if ((option[p].indexOf('function') > -1 || option[p].indexOf('=>') > -1)) {
                    let pm = option[p].substring(option[p].indexOf('(') + 1, option[p].indexOf(')'));
                    pm = pm.replace(/\s+/g, "");
                    let body = option[p].substring(option[p].indexOf('{') + 1, option[p].lastIndexOf('}'));
                    pm == "" ? option[p] = new Function(body) : option[p] = new Function(pm.split(','), body);
                }
            }
        }
    },
    getWidth: function (id) {
        var myChart = this.getChart(id);
        return myChart.getWidth();
    },
    getHeight: function (id) {
        var myChart = this.getChart(id);
        return myChart.getHeight();
    },
    getOption: function (id) {
        var myChart = this.getChart(id);
        return JSON.stringify(myChart.getOption());
    },
    resize: function (id, option) {
        var myChart = this.getChart(id);
        return myChart.resize(option);
    },
    dispatchAction: function (id, option) {
        var myChart = this.getChart(id);
        myChart.dispatchAction(option);
    },
    onEvent: function (id, option) {
        this.formatOption(option);

        var myChart = this.getChart(id);
        myChart.on(option.eventName, option.query, option.handler, option.context);
    },
    offEvent: function (id, option) {
        if (option.handler != null && option.handler != "") {
            this.formatOption(option);
        }

        var myChart = this.getChart(id);
        myChart.off(option.eventName, option.handler);
    },
    convertToPixel: function (id, finder, value) {
        var myChart = this.getChart(id);
        myChart.convertToPixel(finder, value);
    },
    convertFromPixel: function (id, finder, value) {
        var myChart = this.getChart(id);
        myChart.convertFromPixel(finder, value);
    },
    containPixel: function (id, finder, value) {
        var myChart = this.getChart(id);
        var result = myChart.containPixel(finder, value);
        return result;
    },
    showLoading: function (id, type, opts) {
        var myChart = this.getChart(id);
        if (opts != null) {
            myChart.showLoading(type, opts);
        }
        else {
            myChart.showLoading(type || "default", opts);
        }
    },
    hideLoading: function (id) {
        var myChart = this.getChart(id);
        myChart.hideLoading();
    },
    getDataURL: function (id, opts) {
        var myChart = this.getChart(id);
        var result = myChart.getDataURL(opts);
        return result;
    },
    getConnectedDataURL: function (id, opts) {
        var myChart = this.getChart(id);
        var result = myChart.getConnectedDataURL(opts);
        return result;
    },
    appendData: function (id, opts) {
        var myChart = this.getChart(id);
        var result = myChart.appendData(opts);
        return result;
    },
    clear: function (id) {
        var myChart = this.getChart(id);
        var result = myChart.clear();
        return result;
    },
    dispose: function (id) {
        var myChart = this.getChart(id);
        var result = myChart.dispose();
        return result;
    },
    isDisposed: function (id) {
        var myChart = this.getChart(id);
        var result = myChart.isDisposed();
        return result;
    },
    registerMap: function (option) {
        //console.log("registerMap");;
        if (option.geoJSON != null) {
            echarts.registerMap(option.mapName, option.geoJSON, option.specialAreas);
        }
        else if (option.opt != null) {
            echarts.registerMap(option.mapName, option.opt);
        }
    },
    getMap: function (mapName) {
        var map = echarts.getMap(mapName);
        return JSON.stringify(map);
    },
    registerTheme: function (themeName, themeJson) {
        //console.log("registerTheme");
        echarts.registerTheme(themeName, JSON.parse(themeJson));
        this.themes.push(themeName);
    },
    registerLocale: function (locale, localeCfg) {
        echarts.registerTheme(locale, JSON.parse(localeCfg));
    },
    dispose2: function (id) {
        var myChart = this.getChart(id);
        echarts.dispose(myChart);
    },
    connect: function (group) {
        echarts.connect(group);
    },
    disconnect: function (group) {
        echarts.disconnect(group);
    },
    callEvent: function (id, eventName, query, dotnetHelper) {
        //console.log('callEvent');
        var myChart = this.getChart(id);
        myChart.on(eventName, query, (params) => {
            let pm = {
                componentType: params.componentType, seriesType: params.seriesType, color: params.color, dataIndex: params.dataIndex, value: params.value,
                seriesIndex: params.seriesIndex, name: params.name, data: params.data, dataType: params.dataType, type: params.type, seriesName: params.seriesName,
                encode: params.encode, dimensionNames: params.dimensionNames, dimensionIndex: params.dimensionIndex, percent: params.percent, info: params.info
            };

            dotnetHelper.invokeMethodAsync('CallEvent', eventName, JSON.stringify(pm));
        });
    }
}