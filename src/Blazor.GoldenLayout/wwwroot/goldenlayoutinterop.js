export function createGoldenLayout(configuration, container) {
    console.log('Start Create GoldenLayout');
    console.log(configuration);
    console.log('End Create GoldenLayout');
    return new GoldenLayout(configuration, container);
}
export function registerComponent(goldenLayout, dotnetObjectReference, componentName) {
    goldenLayout.registerComponent(componentName, function (container, state) {
        //console.log('Generating guid...');
        // 生成唯一 ID
        const id = crypto.randomUUID();

        // 创建一个 div 元素作为容器
        const div = document.createElement('div');
        div.id = `blazor-${id}`;
        container.getElement().append(div);

        delete state.componentName
       //console.log(state)

        if (state != null) {
            Blazor.rootComponents.add(div, componentName, state);
        }
        else {
            Blazor.rootComponents.add(div, componentName, {});
        }
    })
}


export function createDragSource(goldenLayout, spawnerId, contentItem) {
    console.log("createDragSource called:", { goldenLayout, spawnerId, contentItem });

    if (!goldenLayout || typeof goldenLayout.createDragSource !== 'function') {
        console.error("Invalid GoldenLayout instance or createDragSource not available");
        return;
    }

    const container = document.getElementById(spawnerId);
    if (!container) {
        console.error(`Element with id ${spawnerId} not found`);
        return;
    }

    // 验证 container 是 HTMLElement
    if (!(container instanceof HTMLElement)) {
        console.error("Container is not an HTMLElement:", container);
        return;
    }

    // 验证 contentItem
    if (!contentItem || !contentItem.type || !contentItem.componentName) {
        console.error("Invalid contentItem:", contentItem);
        return;
    }

    try {
        container.draggable = true;
        console.log("Set draggable=true for container:", container.id);

        goldenLayout.createDragSource(container, contentItem);
        console.log("Drag source created successfully for container:", container.id);
    } catch (error) {
        console.error("Error creating drag source:", error);
    }
}