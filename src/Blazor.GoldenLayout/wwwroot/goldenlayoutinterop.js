export function createGoldenLayout(configuration, container) {
    console.log('Start Create GoldenLayout');
    console.log(configuration);
    console.log('End Create GoldenLayout');
    return new GoldenLayout(configuration, container);
}

export function registerComponent(goldenLayout, dotnetObjectReference, componentName) {

    goldenLayout.registerComponent(componentName, function (container, state) {

        console.log('��ʼע��')
        // ����Ψһ ID
        const id = crypto.randomUUID();

    });
} 
    