import React from 'react';
import './style/highlight-filter.css';
import { connect } from 'react-redux'

const mapDispatchToProps = dispatch => ({dispatch});

class HighlightFilter extends React.Component {

    constructor(props) {
        super(props);

        this.handleValue = this.handleValue.bind(this);
        this.handleKeyDown = this.handleKeyDown.bind(this);
    }

    handleKeyDown = e => {
        if (e.key === 'Enter') {
            e.target.blur();
        }
    }

    highlightAction = value => {
        return {
            type: "highlight",
            highlight: value
        }
    }

    updateHighlight() {

    }

    handleValue = event => {
        this.props.dispatch(this.highlightAction(event.target.value))
    };

    render() {
        return (
            <div className="highlight-filter-container">

                <div className="highlight-filter-header">
                    {this.props.title}
                </div>

                <input className="highlight-filter-input"
                    type="text"
                    name="name"
                    placeholder="..."
                    onChange={this.handleValue}
                    onKeyDown={this.handleKeyDown}
                    autoComplete="off"
                />
            </div>
        );
    }
}

export default connect(null, mapDispatchToProps)(HighlightFilter)