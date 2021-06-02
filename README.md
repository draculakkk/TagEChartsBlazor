# 一款基于ECharts的blazor组件，主要以层级标签的方式来使用，所有属性说明可参考echarts官网api说明文档，版本5.1.1

## 简要说明：

### 1：nuget 搜索 agEChartsBlazor安装类库
### 2：Program注册Services.AddECharts();
### 3：wwwroot/index.html(WebAssembly)或_Host.cshtml(Blazor Server)添加
<script src="_content/TagEChartsBlazor/script/echarts.min.js"></script><br/>
<script src="_content/TagEChartsBlazor/script/common.js"></script>
### 4：_Imports.razor 添加 @using TagEChartsBlazor.Components

## 顶层ECharts标签自带的属性说明：

|属性|说明|
|:---|:---|
|Style|标签style样式|
|AutoRender|图表上的任何属性有变动会自动刷新图表，默认关闭|
|debugModel|启用后浏览器控台会输出图表的option项|
|OnRenderComplete|OnAfterRender执行完的委托|
|OnRenderBefore|OnAfterRender执行前的委托|


### 示例1：标准用法，所有标签支持razor动态控制，目前所有formatter属性如需设置函数，需要填写js字符串
```html
<ECharts Style="width: 800px; height: 400px;">
    <Title text="ECharts 入门示例"></Title>
    <Legend data="@(new[] { "销量" })"></Legend>
    <Tooltip></Tooltip>
    <XAxis>
        @foreach (var item in new[] { "衬衫", "羊毛衫", "雪纺衫", "裤子", "高跟鞋", "袜子" })
        {
            <Data value="@item">
                <TextStyle color="red"></TextStyle>
            </Data>
        }
    </XAxis>
    <YAxis>
        <AxisLabel formatter="(value, index) => {return value + ':';}"></AxisLabel>
    </YAxis>
    <Series name="销量" type="bar" data="@(new[] { 5, 20, 36, 10, 10, 20 })">
    </Series>
</ECharts>
```

### 示例2：data属性支持匿名对象，也可以使用Data标签显示创建
```html
<ECharts Style="width: 800px; height: 400px;">
    <Title text="折线图堆叠" />
    <Tooltip trigger="axis" />
    <Legend data="@(new object[] { "邮件营销", "联盟广告", "视频广告", "直接访问", "搜索引擎" })" />
    <Grid left="3%" right="4%" bottom="3%" containLabel="true" />
    <Toolbox>
        <Feature>
            <SaveAsImage></SaveAsImage>
        </Feature>
    </Toolbox>
    <XAxis type="category" boundaryGap="false" data="@(new object[] { "周一", "周二", "周三", "周四", "周五", "周六", "周日" })" />
    <YAxis type="value" />
    <Series name="邮件营销" type="line" stack="总量" data="@(new[] { 120, 132, 101, 134, 90, 230, 210 })" />
    <Series name="联盟广告" type="line" stack="总量" data="@(new[] { 220, 182, 191, 234, 290, 330, 310 })" />
    <Series name="视频广告" type="line" stack="总量" data="@(new[] { 150, 232, 201, 154, 190, 330, 410 })" />
    <Series name="直接访问" type="line" stack="总量" data="@(new[] { 320, 332, 301, 334, 390, 330, 320 })" />
    <Series name="搜索引擎" type="line" stack="总量" data="@(new[] { 820, 932, 901, 934, 1290, 1330, 1320 })" />
</ECharts>
```

### 示例3：顶层ECharts标签支持鼠标委托事件，极少对象没有标签，需要用类生成，如此例的colorStops渐变类
```html
<ECharts Style="width: 800px; height: 400px;"
         OnClick="@(new(async (param, chart) =>
                    {
                        int zoomSize = 6;
                        var sv = dataAxis[System.Math.Max(param.dataIndex.GetValueOrDefault(0) - (zoomSize / 2), 0)];
                        var ev = dataAxis[System.Math.Min(param.dataIndex.GetValueOrDefault(0) + (zoomSize / 2), data.Length - 1)];
                        await chart.DispatchActionAsync(new DataZoomDispatchAction(DataZoomDispatchType.dataZoom, startValue: sv, endValue: ev));
                    }))">
    <Title text="特性示例：渐变色 阴影 点击缩放" subtext="Feature Sample: Gradient Color, Shadow, Click Zoom"></Title>
    <XAxis data="dataAxis" z="10">
        <AxisLabel inside="true">
            <TextStyle color="#fff" />
        </AxisLabel>
        <AxisTick show="false" />
        <AxisLine show="false" />
    </XAxis>
    <YAxis>
        <AxisLabel>
            <TextStyle color="#999" />
        </AxisLabel>
        <AxisTick show="false" />
        <AxisLine show="false" />
    </YAxis>
    <DataZoom type="inside" />
    <Series type="bar" showBackground="true" data="data">
        <ItemStyle>
            <Color x="0" y="0" x2="0" y2="1" colorStops="@(new ColorStops[] { new ColorStops(0, "#83bff6"), new ColorStops(0.5f, "#188df0"), new ColorStops(1, "#188df0") })" />
        </ItemStyle>
        <Emphasis>
            <Color x="0" y="0" x2="0" y2="1" colorStops="@(new ColorStops[] { new ColorStops(0, "#2378f7"), new ColorStops(0.7f, "#2378f7"), new ColorStops(1, "#83bff6") })" />
        </Emphasis>
    </Series>
</ECharts>
```

### 示例4：演示使用主题和外部资源，由于异步加载可能会执行2次render，且echarts会默认缓存首次加载信息，这里手动控制了外部资源加载完再输出标签，EChartsHelper对应echarts的全局类

```html
@inject EChartsHelper echartHelper
@inject HttpClient Http

@if (initSuccess)
{
    <ECharts Style="width: 800px; height: 400px;" theme="wyy"
             OnMouseOver="@(new(async (param, chart) =>
                            {
                                await chart.DispatchActionAsync(new DispatchAction(DispatchType.highlight, geoIndex: 0, name: param.name));

                            }, new { seriesIndex = 0 }))"
             OnMouseOut="@(new(async (param, chart) =>
                           {
                               await chart.DispatchActionAsync(new DispatchAction(DispatchType.downplay, geoIndex: 0, name: param.name));
                           }, new { seriesIndex = 0 }))">
        <Tooltip />
        <Geo left="10" right="50%" map="organ_diagram" selectedMode="true">
            <Emphasis focus="self">
                <ItemStyle color="null" />
                <Label position="bottom" distance="0" textBorderColor="#fff" textBorderWidth="2" />
            </Emphasis>
            <Blur />
            <Select>
                <ItemStyle color="#b50205" />
                <Label show="false" textBorderColor="#fff" textBorderWidth="2" />
            </Select>
        </Geo>
        <Grid left="60%" top="20%" bottom="20%" />
        <XAxis />
        <YAxis data="@(new object[] { "heart", "large-intestine", "small-intestine", "spleen", "kidney", "lung", "liver" })" />
        <Series type="bar" data="@(new[] { 121, 321, 141, 52, 198, 289, 139 })">
            <Emphasis focus="self" />
        </Series>
    </ECharts>
}
@code {
  private bool initSuccess;
  protected async override Task OnInitializedAsync()
  {
      string mapsvg = await Http.GetStringAsync("asset/Veins_Medical_Diagram_clip_art.svg");
      await echartHelper.RegisterMapAsync(new RegisterMapOption("organ_diagram", opt: new MapOpt(svg: mapsvg)));
      string json = await Http.GetStringAsync("json/chalk.json");
      await echartHelper.RegisterThemeAsync("wyy", json);
  }
}
```
