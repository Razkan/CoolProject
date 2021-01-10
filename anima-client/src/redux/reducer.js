const initialState = {
    highlight: {
        value: ""
    },
    sidebar: {
        value: ""
    }
};

export default function appReducer(state = initialState, action) {
    switch (action.type) {
        case 'highlight': {
            var newState = { ...state };
            newState.highlight = {
                value: action.highlight
            }
            return newState;
        }
        case 'sidebar': {
            var newState = { ...state };
            newState.sidebar = {
                value: action.sidebar
            }
            return newState;
        }
        default:
            return state
    }
}