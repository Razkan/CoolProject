const initialState = {
    highlight: {
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
        default:
            return state
    }
}