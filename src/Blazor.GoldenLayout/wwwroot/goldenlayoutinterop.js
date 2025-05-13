export function createGoldenLayout(configuration, container) {
    console.log('Start Create GoldenLayout');
    console.log(configuration);
    console.log('End Create GoldenLayout');
    return new GoldenLayout(configuration, container);
}

export function registerComponent(goldenLayout, dotnetObjectReference, componentName) {
    goldenLayout.registerComponent(componentName, function (container, state) {
        console.log('Generating guid...');
        // ����Ψһ ID
        const id = crypto.randomUUID();
        // ����һ�� div Ԫ����Ϊ����
        const div = document.createElement('div');
        div.id = `blazor-${id}`;
        container.getElement().append(div);
        // ���� Razor ���
        Blazor.rootComponents.add(div, componentName, state);
    });
}
