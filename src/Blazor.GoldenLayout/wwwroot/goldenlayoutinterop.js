export function createGoldenLayout(configuration, container) {
    console.log('Start Create GoldenLayout');
    console.log(configuration);
    console.log('End Create GoldenLayout');
    return new GoldenLayout(configuration, container);
}

export function registerComponent(goldenLayout, dotnetObjectReference, componentName) {

    goldenLayout.registerComponent(componentName, function (container, state) {

        console.log('开始注册')
        // 生成唯一 ID
        const id = crypto.randomUUID();

    });
} 
    