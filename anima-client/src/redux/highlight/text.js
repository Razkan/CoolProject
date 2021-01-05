import React from 'react';
import { connect } from 'react-redux';
import './text.css';

const mapStateToProps = (state) => ({ highlight: state.highlight.value });

class Text extends React.Component {
	constructor(props) {
		super(props);

		this.hasHighlight = this.props.hasHighlight
			? this.props.hasHighlight
			: () => { };
	}

	getHighlightText(value, highlight) {
		var highlight = highlight.toLowerCase();
		
		const getIndex = (value) => {
			return value.toLowerCase().indexOf(highlight);
		}
		
		if(getIndex(value) == -1)
			return [];

		var arr = [];
		var values = value.split(" ");

		for (var value of values) {

			var valueArr = [];
			for (var index = getIndex(value); index > -1; index = getIndex(value)) {

				var begin = value.substring(0, index);
				var match = value.substring(index, index + highlight.length);

				value = value.substring(index + highlight.length, value.length);

				valueArr.push({ begin, match, end: "" });
			}

			if (value)
				valueArr.push({ begin: "", match: "", end: value });
			arr.push(valueArr);
		}

		var textArr = [];
		for (var wordArr of arr) {
			var text = "<div style=\"display: flex; flex-wrap: wrap; white-space: pre;\">";
			for (var word of wordArr) {

				if (word.begin) {
					text += word.begin;
				}
				if (word.match) {
					text += "<div style=\"background-color: yellow;\">" + word.match + "</div>";

				}
				if (word.end) {
					text += word.end;
				}
			}
			text += "<div>&nbsp;</div></div>";
			textArr.push(text);
		}

		return textArr.join("");
	}

	render() {
		var value = this.props.value;
		var highlight = this.props.highlight;

		if (highlight) {

			var highlightText = this.getHighlightText(value, highlight);
			if (highlightText.length > 0) {

				this.hasHighlight(true);

				const textContainer = {
					display: "flex",
					flexWrap: "wrap",
					whiteSpace: "pre"
				}

				var innerHtml = { __html: highlightText };
				return (
					<div style={textContainer} dangerouslySetInnerHTML={innerHtml}>
					</div>
				);
			}
		}

		this.hasHighlight(false);
		return (
			<div>{value}</div>
		);
	}
}

export default connect(mapStateToProps)(Text);
