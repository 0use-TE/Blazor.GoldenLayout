export function createGoldenLayout(configuration, container) {
    console.log('Start Create GoldenLayout');
    console.log(configuration);
    console.log('End Create GoldenLayout');
    return new GoldenLayout(configuration, container);
}

export function registerComponent(goldenLayout, dotnetObjectReference, componentName) {
    goldenLayout.registerComponent(componentName, function (container, state) {
        console.log('Generating guid...');
        // 生成唯一 ID
        const id = crypto.randomUUID();
        // 创建一个 div 元素作为容器
        const div = document.createElement('div');
        div.id = `blazor-${id}`;
        container.getElement().append(div);
        // 挂载 Razor 组件
        Blazor.rootComponents.add(div, componentName, state);
    });
}
