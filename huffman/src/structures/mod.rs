#[derive(Debug)]
pub struct Node {
    pub ch: Option<char>,
    pub frequency: i32,
    pub left: Option<Box<Node>>,
    pub right: Option<Box<Node>>,
}

impl Node {
    pub fn new(frequency: i32, ch: Option<char>) -> Self {
        Self {
            frequency,
            ch,
            left: None,
            right: None,
        }
    }
}
