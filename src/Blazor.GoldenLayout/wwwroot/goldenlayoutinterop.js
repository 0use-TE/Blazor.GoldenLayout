const goldenlayout_basecss = 'basecss';
const goldenlayout_minjs = 'minjs';

function loadScriptIfNeeded(id, src) {
    return new Promise((resolve, reject) => {
        if (document.getElementById(id)) {
            resolve(); 
            return;
        }
        const script = document.createElement('script');
        script.src = src;
        script.id = id;
        script.onload = () => resolve();
        script.onerror = () => reject(`Failed to load script: ${src}`);
        document.body.appendChild(script);
    });
}

function loadCssIfNeeded(id, href) {
    if (document.getElementById(id)) return;
    const link = document.createElement('link');
    link.rel = 'stylesheet';
    link.href = href;
    link.id = id;
    document.head.appendChild(link);
}

export async function createGoldenLayout(dotnetObjectReference, configuration, container) {
    await loadScriptIfNeeded('jquery', '_content/Blazor.GoldenLayout/jquery.min.js');
    await loadScriptIfNeeded(goldenlayout_minjs, '_content/Blazor.GoldenLayout/goldenlayout.min.js');
    loadCssIfNeeded(goldenlayout_basecss, '_content/Blazor.GoldenLayout/goldenlayout-base.css');

    const layout = new GoldenLayout(configuration, container);

    layout.on('initialised', () => dotnetObjectReference.invokeMethodAsync('OnInitialised'));
    layout.on('stateChanged', () => dotnetObjectReference.invokeMethodAsync('OnStateChanged'));
    layout.on('windowOpened', () => dotnetObjectReference.invokeMethodAsync('OnWindowOpened'));
    layout.on('windowClosed', () => dotnetObjectReference.invokeMethodAsync('OnWindowClosed'));
    layout.on('selectionChanged', () => dotnetObjectReference.invokeMethodAsync('OnSelectionChanged'));
    layout.on('itemDestroyed', () => dotnetObjectReference.invokeMethodAsync('OnItemDestroyed'));
    layout.on('itemCreated', () => dotnetObjectReference.invokeMethodAsync('OnItemCreated'));
    layout.on('componentCreated', () => dotnetObjectReference.invokeMethodAsync('OnComponentCreated'));
    layout.on('rowCreated', () => dotnetObjectReference.invokeMethodAsync('OnRowCreated'));
    layout.on('columnCreated', () => dotnetObjectReference.invokeMethodAsync('OnColumnCreated'));
    layout.on('stackCreated', () => dotnetObjectReference.invokeMethodAsync('OnStackCreated'));
    layout.on('tabCreated', () => dotnetObjectReference.invokeMethodAsync('OnTabCreated'));

    return layout;
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


export function createDragSource(dotnetObjectReference,goldenLayout, spawnerId, contentItem) {
    console.log("createDragSource called:", { goldenLayout, spawnerId, contentItem });


    const container = document.getElementById(spawnerId);

    try {
        goldenLayout.createDragSource(container, contentItem);
    } catch (error) {
        console.error("Error creating drag source:", error);
    }
}

export function createBySelection(dotnetObjectReference, goldenLayout, spawnerId, contentItem) {
    var container = document.getElementById(spawnerId);

    container.addEventListener('click', function () {
        //console.log("select")
        if (goldenLayout.selectedItem === null) {
            dotnetObjectReference.invokeMethodAsync('OnNoItemSelected');
        }
        else {
            goldenLayout.selectedItem.addChild(contentItem);
        }
    });
}
